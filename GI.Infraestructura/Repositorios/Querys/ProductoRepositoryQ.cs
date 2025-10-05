using Dapper;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Querys;
using GI.Infraestructura.Comunes;
using GI.Infraestructura.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;

namespace GI.Infraestructura.Repositorios.Querys
{
    public class ProductoRepositoryQ(DbConexion dbConexion, ILogger<ProductoRepositoryQ> logger) : IProductosRepositorioQ
    {
        private readonly DbConexion _dbConexion = dbConexion;
        private readonly ILogger<ProductoRepositoryQ> _logger = logger;

        public async Task<SingleResponse<ProductoEN>> BuscarPorID(int Id)
        {
            SingleResponse<ProductoEN> oResp = new();
            DynamicParameters parametros = Utilitarios.GenerarParametros(new
            {
                IID = Id,
            });

            try
            {
                IDbConnection connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QueryFirstOrDefaultAsync<ProductoEN>(
                    sql: "Sp_ProductosQ_BuscarPorID",
                    commandType: CommandType.StoredProcedure,
                    param: parametros
                );
            }
            catch (SqlException exsql)
            {
                _logger.LogError(exsql, "Ocurrio un exepcion(Sql) al intentar bucar el producto con ID: {id}", Id);
                oResp.ErrorCode = exsql.Number;
                oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                oResp.StatusType = "SQL-ERROR";
                return oResp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un exepcion(c#) al intentar buscar el producto.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
                return oResp;
            }

            return oResp;
        }

        public async Task<ListResponse<ProductoEN>> Consultar(ProductoEN oFiltros)
        {
            ListResponse<ProductoEN> oResp = new();
            DynamicParameters parametros = Utilitarios.GenerarParametros(new
            {
                IC_Codigo = oFiltros.C_Codigo,
                IC_Nombre = oFiltros.C_Nombre,
                IID_Categoria = oFiltros.ID_Categoria,
                IID_UnidadMedida = oFiltros.ID_UnidadMedida,
                IID_Marca = oFiltros.ID_Marca,
                IID_Estado = oFiltros.ID_Estado,
                IC_SKU = oFiltros.C_SKU
            });

            try
            {
                IDbConnection connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QueryAsync<ProductoEN>(
                   sql: "Sp_ProductosQ_Consultar",
                   commandType: CommandType.StoredProcedure,
                   param: parametros
                );
            }
            catch (SqlException exsql)
            {
                _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al intentar consultar los productos.", exsql.Number);
                oResp.ErrorCode = exsql.Number;
                oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                oResp.StatusType = "SQL-ERROR";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al intentar consultar los productos.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }
    }
}
