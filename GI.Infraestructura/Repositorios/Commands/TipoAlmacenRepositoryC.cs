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
    public class TipoAlmacenRepositoryC(DbConexion dbConexion, ILogger<TipoAlmacenRepositoryC> logger) : ITipoAlmacenRepositorioC
    {
        private readonly DbConexion _dbConexion = dbConexion;
        private readonly ILogger<TipoAlmacenRepositoryC> _logger = logger;

        public async Task<SingleResponse<TipoAlmacenEN>> Actualizar(TipoAlmacenEN oTipoAlmacen)
        {
            if (oTipoAlmacen == null)
            {
                throw new ArgumentNullException(nameof(oTipoAlmacen));
            }

            var oResp = new SingleResponse<TipoAlmacenEN>();

            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IID  = oTipoAlmacen.ID,
                IC_Nombre = oTipoAlmacen.C_Nombre,
                IC_Descripcion = oTipoAlmacen.C_Descripcion,
                IB_Activo = oTipoAlmacen.B_Activo,
                IC_Usuario_Modificacion = oTipoAlmacen.C_Usuario_Modificacion
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QuerySingleAsync<TipoAlmacenEN>(
                         sql: "Sp_TipoAlmacenC_Actualizar",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al actualizar una Tipo de Almacen.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al actualizar una Tipo de Almacen.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }

        public async Task<SingleResponse<TipoAlmacenEN>> Crear(TipoAlmacenEN oTipoAlmacen)
        {
            if (oTipoAlmacen == null)
            {
                throw new ArgumentNullException(nameof(oTipoAlmacen));
            }

            var oResp = new SingleResponse<TipoAlmacenEN>();

            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IC_Nombre = oTipoAlmacen.C_Nombre,
                IC_Descripcion = oTipoAlmacen.C_Descripcion,
                IC_Usuario_Creacion = oTipoAlmacen.C_Usuario_Creacion
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QuerySingleAsync<TipoAlmacenEN>(
                         sql: "Sp_TipoAlmacenC_Crear",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al crear una Tipo de Almacen.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al crear una Tipo de Almacen.");
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
                         sql: "Sp_TipoAlmacenC_Eliminar",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al eliminar una Tipo de Almacen.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al eliminar una Tipo de Almacen.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }
    }
}
