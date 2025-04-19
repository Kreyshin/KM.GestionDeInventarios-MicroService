using Dapper;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Querys;
using GI.Infraestructura.Comunes;
using GI.Infraestructura.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Infraestructura.Repositorios.Querys
{
    public class CategoriaRepositoryQ(DbConexion dbConexion, ILogger<CategoriaRepositoryQ> logger) : ICategoriaRepositorioQ
    {
        private readonly DbConexion _dbConexion = dbConexion;
        private readonly ILogger<CategoriaRepositoryQ> _logger = logger;

        public async Task<SingleResponse<CategoriaEN>> BuscarPorID(int id)
        {
            SingleResponse<CategoriaEN> oResp = new();
            DynamicParameters parametros = Utilitarios.GenerarParametros(new
            {
                IID = id,
            });

            try
            {
                IDbConnection connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QueryFirstOrDefaultAsync<CategoriaEN>(
                    sql: "Sp_CategoriaQ_BuscarPorID",
                    commandType: CommandType.StoredProcedure,
                    param: parametros
                );
            }
            catch (SqlException exsql)
            {
                _logger.LogError(exsql, "Ocurrio un exepcion(Sql) al intentar bucar la Categoria con ID: {id}", id);
                oResp.ErrorCode = exsql.Number;
                oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                oResp.StatusType = "SQL-ERROR";
                return oResp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un exepcion(c#) al intentar buscar la Categoria.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
                return oResp;
            }

            return oResp;
        }

        public async Task<ListResponse<CategoriaEN>> Consultar(CategoriaEN flt)
        {
            ListResponse<CategoriaEN> oResp = new();
            DynamicParameters parametros = Utilitarios.GenerarParametros(new
            {
                IC_Nombre = flt.C_Nombre,
                IC_Estado = flt.C_Estado,
            });

            try
            {
                IDbConnection connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QueryAsync<CategoriaEN>(
                   sql: "Sp_CategoriaQ_Consultar",
                   commandType: CommandType.StoredProcedure,
                   param: parametros
                );
            }
            catch (SqlException exsql)
            {
                _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al intentar consultar las categorias.", exsql.Number);
                oResp.ErrorCode = exsql.Number;
                oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                oResp.StatusType = "SQL-ERROR";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al intentar consultar las categorias.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }
    }
}
