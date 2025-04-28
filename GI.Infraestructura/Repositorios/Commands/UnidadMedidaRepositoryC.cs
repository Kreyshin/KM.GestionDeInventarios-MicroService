using Dapper;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Commands;
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

namespace GI.Infraestructura.Repositorios.Commands
{
    public class UnidadMedidaRepositoryC(DbConexion dbConexion, ILogger<UnidadMedidaRepositoryC> logger) : IUnidadMedidaRepositorioC
    {
        private readonly DbConexion _dbConexion = dbConexion;
        private readonly ILogger<UnidadMedidaRepositoryC> _logger = logger;

        public async Task<SingleResponse<UnidadMedidaEN>> Actualizar(UnidadMedidaEN oUnidadMedida)
        {
            if (oUnidadMedida == null)
            {
                throw new ArgumentNullException(nameof(oUnidadMedida));
            }

            var oResp = new SingleResponse<UnidadMedidaEN>();

            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IID  = oUnidadMedida.ID,
                IC_Nombre = oUnidadMedida.C_Nombre,
                IB_Activo = oUnidadMedida.B_Activo,
                IC_Usuario_Modificacion = oUnidadMedida.C_Usuario_Modificacion
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QuerySingleAsync<UnidadMedidaEN>(
                         sql: "Sp_UnidadMedidaC_Actualizar",
                         commandType: CommandType.StoredProcedure,
                         param: objParam
                       );
            }
            catch (SqlException exsql)
            {
                if (exsql.Number == 50001)
                {
                    // Es un mensaje de validación del SP, no un error crítico
                    _logger.LogWarning("Validación de negocio: {Mensaje}", exsql.Message);
                    oResp.ErrorCode = 50001;
                    oResp.StatusMessage = exsql.Message;
                    oResp.StatusType = "VALIDACION";
                }
                else
                {
                    // Es un error real de SQL
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al actualizar una Unidad de Medida.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al actualizar una Unidad de Medida.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }

        public async Task<SingleResponse<UnidadMedidaEN>> Crear(UnidadMedidaEN oUnidadMedida)
        {
            if (oUnidadMedida == null)
            {
                throw new ArgumentNullException(nameof(oUnidadMedida));
            }

            var oResp = new SingleResponse<UnidadMedidaEN>();

            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IC_Nombre = oUnidadMedida.C_Nombre,                
                IC_Usuario_Creacion = oUnidadMedida.C_Usuario_Creacion
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QuerySingleAsync<UnidadMedidaEN>(
                         sql: "Sp_UnidadMedidaC_Crear",
                         commandType: CommandType.StoredProcedure,
                         param: objParam
                       );
            }
            catch (SqlException exsql)
            {
                if (exsql.Number == 50001)
                {
                    // Es un mensaje de validación del SP, no un error crítico
                    _logger.LogWarning("Validación de negocio: {Mensaje}", exsql.Message);
                    oResp.ErrorCode = 50001;
                    oResp.StatusMessage = exsql.Message;
                    oResp.StatusType = "VALIDACION";
                }
                else
                {
                    // Es un error real de SQL
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al crear una Unidad de Medida.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al crear una Unidad de Medida.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }

        public async Task<SingleResponse<int>> Eliminar(int id)
        {
            var oResp = new SingleResponse<int>();
            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IID = id
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.ExecuteAsync(
                         sql: "Sp_UnidadMedidaC_Eliminar",
                         commandType: CommandType.StoredProcedure,
                         param: objParam
                       );
            }
            catch (SqlException exsql)
            {
                if (exsql.Number == 50001)
                {
                    // Es un mensaje de validación del SP, no un error crítico
                    _logger.LogWarning("Validación de negocio: {Mensaje}", exsql.Message);
                    oResp.ErrorCode = 50001;
                    oResp.StatusMessage = exsql.Message;
                    oResp.StatusType = "VALIDACION";
                }
                else
                {
                    // Es un error real de SQL
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al eliminar una Unidad de Medida.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al eliminar una Unidad de Medida.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }
    }
}
