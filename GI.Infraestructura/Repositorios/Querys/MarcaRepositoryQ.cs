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
    class MarcaRepositoryQ(DbConexion dbConexion, ILogger<MarcaRepositoryQ> logger) : IMarcaRepositorioQ
    {
        private readonly DbConexion _dbConexion = dbConexion;
        private readonly ILogger<MarcaRepositoryQ> _logger = logger;

        public async Task<SingleResponse<MarcaEN>> BuscarPorID(int id)
        {
            SingleResponse<MarcaEN> oResp = new();
            DynamicParameters parametros = Utilitarios.GenerarParametros(new
            {
                IID = id,
            });

            try
            {
                IDbConnection connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QueryFirstOrDefaultAsync<MarcaEN>(
                    sql: "Sp_MarcaQ_BuscarPorID",
                    commandType: CommandType.StoredProcedure,
                    param: parametros
                );
            }
            catch (SqlException exsql)
            {
                _logger.LogError(exsql, "Ocurrio un exepcion(Sql) al intentar bucar la Marca con ID: {id}", id);
                oResp.ErrorCode = exsql.Number;
                oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                oResp.StatusType = "SQL-ERROR";
                return oResp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un exepcion(c#) al intentar buscar la Marca.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
                return oResp;
            }

            return oResp;
        }

        public async Task<ListResponse<MarcaEN>> Consultar(MarcaEN flt)
        {
            ListResponse<MarcaEN> oResp = new();
            DynamicParameters parametros = Utilitarios.GenerarParametros(new
            {
                IC_Nombre = flt.C_Nombre,
                IC_Estado = flt.C_Estado,
            });

            try
            {
                IDbConnection connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QueryAsync<MarcaEN>(
                   sql: "Sp_MarcaQ_Consultar",
                   commandType: CommandType.StoredProcedure,
                   param: parametros
                );
            }
            catch (SqlException exsql)
            {
                _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al intentar consultar las Marcas.", exsql.Number);
                oResp.ErrorCode = exsql.Number;
                oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                oResp.StatusType = "SQL-ERROR";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al intentar consultar las Marcas.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }
    
    }
}
