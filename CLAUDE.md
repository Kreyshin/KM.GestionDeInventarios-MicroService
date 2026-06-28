# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Build the solution
dotnet build KM.GestionInventarios.MS.sln

# Run the API
dotnet run --project GI.Api/GI.Api.csproj

# Run all tests
dotnet test GI.Api.Tests/GI.Api.Tests.csproj

# Run a single test class
dotnet test GI.Api.Tests/GI.Api.Tests.csproj --filter "FullyQualifiedName~IProductosCrudCUTests"

# Run a single test method
dotnet test GI.Api.Tests/GI.Api.Tests.csproj --filter "FullyQualifiedName~IProductosCrudCUTests.Crear_ShouldReturnSuccess_WhenValidRequest"
```

The connection string is configured in `GI.Api/appsettings.Development.json` under key `cnSql` (SQL Server / SQLEXPRESS).

## Architecture

This is a .NET 8 ASP.NET Core microservice for inventory management. It follows Clean Architecture with CQRS separation at the repository level. The solution has six projects:

| Project | Responsibility |
|---|---|
| `GI.Api` | Controllers, startup wiring, `DbConfiguracion` |
| `GI.Aplicacion` | Use cases, DTOs, AutoMapper profiles, FluentValidation validators |
| `GI.Dominion` | Domain entities, repository interfaces, shared response types |
| `GI.Infraestructura` | Dapper-based repository implementations, `DbConexion` |
| `GI.Logging` | Serilog setup (file sinks: `general-` and `errors-`) |
| `GI.Api.Tests` | xUnit + Moq unit tests (interface-level mocks only) |

Dependency direction: `GI.Api` → `GI.Aplicacion` → `GI.Dominion` ← `GI.Infraestructura`.

## Request Flow

```
Controller → ICrudCU (use case) → IRepositorioQ / IRepositorioC → Dapper SP call
```

All persistence goes through stored procedures. The use case maps `RQ` → `EN` via AutoMapper, sets audit fields from `IAuditoriaHelp`, calls the repository, then maps `EN` → `RE` and sets `StatusCode` on the response object. The controller dispatches on `StatusCode` with a switch expression.

## Naming Conventions

| Suffix | Meaning | Example |
|---|---|---|
| `EN` | Domain entity | `ProductoEN` |
| `RQ` | Request DTO | `ProductoCrearRQ`, `ProductoConsultarRQ` |
| `RE` | Response DTO | `ProductoCrearRE`, `ProductoBuscarPorIDRE` |
| `CU` | Use case interface | `IProductosCrudCU` |
| `RepositorioQ` | Query repository interface | `IProductosRepositorioQ` |
| `RepositorioC` | Command repository interface | `IProductosRepositorioC` |
| `ProfileAM` | AutoMapper profile | `ProductosCrudProfileAM` |

Entity properties follow the prefix convention `C_` (string), `ID_` (int FK), `ID` (int PK).

## Stored Procedure Naming

- Queries: `Sp_{Entidad}Q_{Accion}` — e.g., `Sp_ProductosQ_Consultar`, `Sp_ProductosQ_BuscarPorID`
- Commands: `Sp_{Entidad}C_{Accion}` — e.g., `Sp_ProductosC_Crear`, `Sp_ProductosC_Actualizar`, `Sp_ProductosC_Eliminar`

## Parameter Convention (`Utilitarios.GenerarParametros`)

Parameters are built by passing an anonymous object to `Utilitarios.GenerarParametros`. The prefix of each property name determines its `DbType`:

| Prefix | DbType |
|---|---|
| `IID` | `Int32` input |
| `IC` | `String` input |
| `IB` | `Boolean` input |
| `O` | Output parameter |

## Error Handling Pattern

Repositories distinguish three outcomes:

| Condition | `ErrorCode` | `StatusType` | Meaning |
|---|---|---|---|
| Success | `0` | — | Proceed normally |
| Business rule violation from SP | `50001` | `"VALIDACION"` | Return 400 to client |
| Unexpected SQL error | `exsql.Number` | `"SQL-ERROR"` | Return 500 |
| C# exception | `50100` | `"BACKEND-ERROR"` | Return 500 |

Use cases translate `ErrorCode` to HTTP `StatusCode` (`200`, `400`, `500`). Controllers dispatch on `StatusCode` with a switch expression.

## Response Types

All repository and use-case methods return one of:

- `SingleResponse<T>` — single record (inherits `RepositoryResult`)
- `ListResponse<T>` — collection (inherits `RepositoryResult`)

`RepositoryResult` carries: `StatusCode`, `ErrorCode`, `ErrorMessage`, `StatusMessage`, `StatusType`.

## Auditing

`AuditoriaMiddleware` reads the `Authorization: Bearer <token>` header on every request, decodes it with `IJwtService`, and stores the username in the scoped `IAuditoriaHelp`. Use cases inject `IAuditoriaHelp` to populate `C_Usuario_Creacion` and `C_Usuario_Modificacion` on entities before persisting.

## Adding a New Entity

Follow the pattern from any existing entity (e.g., `Producto`):

1. **Domain** — Add `{Entidad}EN.cs` in `GI.Dominion/Entidades/`, and `I{Entidad}RepositorioQ.cs` / `I{Entidad}RepositorioC.cs` in `GI.Dominion/Interfaces/`.
2. **Infrastructure** — Add `{Entidad}RepositoryQ.cs` / `{Entidad}RepositoryC.cs` in `GI.Infraestructura/Repositorios/`. Register in `InyeccionInfraestructuraEX.cs`.
3. **Application** — Under `GI.Aplicacion/Funcionalidades/MA-{Entidad}/` add: DTOs (`Dtos/Request/`, `Dtos/Response/`), interface (`Interfaces/I{Entidad}CrudCU.cs`), use case (`CasosUso/{Entidad}CrudCU.cs`), mapper (`Mappers/{Entidad}CrudProfileAM.cs`), validator (`Validadores/{Entidad}CrearRQValidator.cs`). Register all in `InyeccionAplicacionEX.cs`.
4. **API** — Add controller in `GI.Api/Controllers/Maestros/` with route `v1/GestionInventarios/[controller]`.
5. **Tests** — Add `I{Entidad}CrudCUTests.cs` in `GI.Api.Tests/Aplicacion/Funcionalidades/` mocking the use case interface.

## API Route

All controllers use the pattern: `v1/GestionInventarios/[controller]`

Example: `GET /v1/GestionInventarios/Producto`
