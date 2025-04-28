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
    public class TipoAlmacenRepositoryQ(DbConexion dbConexion, ILogger<TipoAlmacenRepositoryQ> logger) : ITipoAlmacenRepositorioQ
    {
        private readonly DbConexion _dbConexion = dbConexion;
        private readonly ILogger<TipoAlmacenRepositoryQ> _logger = logger;

        public async Task<SingleResponse<TipoAlmacenEN>> BuscarPorID(int id)
        {
            SingleResponse<TipoAlmacenEN> oResp = new();
            DynamicParameters parametros = Utilitarios.GenerarParametros(new
            {
                IID = id,
            });

            try
            {
                IDbConnection connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QueryFirstOrDefaultAsync<TipoAlmacenEN>(
                    sql: "Sp_TipoAlmacenQ_BuscarPorID",
                    commandType: CommandType.StoredProcedure,
                    param: parametros
                );
            }
            catch (SqlException exsql)
            {
                _logger.LogError(exsql, "Ocurrio un exepcion(Sql) al intentar bucar la TipoAlmacen con ID: {id}", id);
                oResp.ErrorCode = exsql.Number;
                oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                oResp.StatusType = "SQL-ERROR";
                return oResp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un exepcion(c#) al intentar buscar la TipoAlmacen.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
                return oResp;
            }

            return oResp;
        }

        public async Task<ListResponse<TipoAlmacenEN>> Consultar(TipoAlmacenEN flt)
        {
            ListResponse<TipoAlmacenEN> oResp = new();
            DynamicParameters parametros = Utilitarios.GenerarParametros(new
            {
                IC_Nombre = flt.C_Nombre,
                IC_Descripcion = flt.C_Descripcion,
                IC_Estado = flt.C_Estado,
            });

            try
            {
                IDbConnection connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QueryAsync<TipoAlmacenEN>(
                   sql: "Sp_TipoAlmacenQ_Consultar",
                   commandType: CommandType.StoredProcedure,
                   param: parametros
                );
            }
            catch (SqlException exsql)
            {
                _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al intentar consultar las Tipo de Almacenes.", exsql.Number);
                oResp.ErrorCode = exsql.Number;
                oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                oResp.StatusType = "SQL-ERROR";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al intentar consultar las Tipo de Almacenes.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }
    }
}
