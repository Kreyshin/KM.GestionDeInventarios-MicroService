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
    public class AlmacenesRepositoryC(DbConexion dbConexion, ILogger<AlmacenesRepositoryC> logger) : IAlmacenesRepositorioC
    {
        private readonly DbConexion _dbConexion = dbConexion;
        private readonly ILogger<AlmacenesRepositoryC> _logger = logger;


        public async Task<SingleResponse<AlmacenEN>> Crear(AlmacenEN oAlmacen)
        {
            if (oAlmacen == null)
            {
                throw new ArgumentNullException(nameof(oAlmacen));
            }

            var oResp = new SingleResponse<AlmacenEN>();

            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IC_Codigo = oAlmacen.C_Codigo,
                IC_Nombre = oAlmacen.C_Nombre,
                IC_Direccion = oAlmacen.C_Direccion,
                IID_TipoAlmacen = oAlmacen.ID_TipoAlmacen,
                IC_Ubigeo = oAlmacen.C_Ubigeo,
                IC_Telefono = oAlmacen.C_Telefono,
                IC_Latitud = oAlmacen.C_Latitud,
                IC_Longitud = oAlmacen.C_Longitud,
                IC_Usuario_Creacion = oAlmacen.C_Usuario_Creacion
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QuerySingleAsync<AlmacenEN>(
                         sql: "Sp_AlmacenesC_Crear",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al crear un Almacen.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al crear un Almacen.");
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
                         sql: "Sp_AlmacenesC_Eliminar",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al eliminar un Almacen.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al eliminar un Almacen.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }

        public async Task<SingleResponse<AlmacenEN>> Actualizar(AlmacenEN oAlmacen)
        {
            if (oAlmacen == null)
            {
                throw new ArgumentNullException(nameof(oAlmacen));
            }

            var oResp = new SingleResponse<AlmacenEN>();

            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IID = oAlmacen.ID,
                IC_Nombre = oAlmacen.C_Nombre,
                IC_Direccion = oAlmacen.C_Direccion,
                IID_TipoAlmacen = oAlmacen.ID_TipoAlmacen,
                IID_Estado = oAlmacen.ID_Estado,
                IC_Ubigeo = oAlmacen.C_Ubigeo,
                IC_Telefono = oAlmacen.C_Telefono,
                IC_Latitud = oAlmacen.C_Latitud,
                IC_Longitud = oAlmacen.C_Longitud,

                IC_Usuario_Modificacion = oAlmacen.C_Usuario_Modificacion
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QuerySingleAsync<AlmacenEN>(
                         sql: "Sp_AlmacenesC_Actualizar",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al actualizar un Almacen.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al actualizar un Almacen.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }
    }
}
