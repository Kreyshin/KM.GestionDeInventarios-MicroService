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
    public class ProductoRepositoryC(DbConexion dbConexion, ILogger<ProductoRepositoryC> logger) : IProductosRepositorioC
    {
        private readonly DbConexion _dbConexion = dbConexion;
        private readonly ILogger<ProductoRepositoryC> _logger = logger;

        public async Task<SingleResponse<ProductoEN>> Actualizar(ProductoEN oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            var oResp = new SingleResponse<ProductoEN>();

            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IID = oRegistro.ID,
                IC_Nombre = oRegistro.C_Nombre,
                IC_Descripcion = oRegistro.C_Descripcion,
                IC_SKU = oRegistro.C_SKU,
                IID_Categoria = oRegistro.ID_Categoria,
                IID_UnidadMedida = oRegistro.ID_UnidadMedida,
                IID_Marca = oRegistro.ID_Marca,
                IID_Estado = oRegistro.ID_Estado,
                IC_Usuario_Modificacion = oRegistro.C_Usuario_Modificacion
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QuerySingleAsync<ProductoEN>(
                         sql: "Sp_ProductosC_Actualizar",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al actualizar un producto.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al actualizar un Producto.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }

        public async Task<SingleResponse<ProductoEN>> Crear(ProductoEN oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            var oResp = new SingleResponse<ProductoEN>();

            DynamicParameters objParam = Utilitarios.GenerarParametros(new
            {
                IC_Codigo = oRegistro.C_Codigo,
                IC_Nombre = oRegistro.C_Nombre,
                IC_Descripcion = oRegistro.C_Descripcion,
                IID_Categoria = oRegistro.ID_Categoria,
                IID_UnidadMedida = oRegistro.ID_UnidadMedida,
                IID_Marca = oRegistro.ID_Marca,
                IID_Estado = oRegistro.ID_Estado,
                IC_SKU = oRegistro.C_SKU,
                IC_Usuario_Creacion = oRegistro.C_Usuario_Creacion
            });

            try
            {
                using var connection = _dbConexion.CrearConexion;
                oResp.Data = await connection.QuerySingleAsync<ProductoEN>(
                         sql: "Sp_ProductosC_Crear",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al crear un producto.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al crear un producto.");
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
                         sql: "Sp_ProductosC_Eliminar",
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
                    _logger.LogError(exsql, "SQL Error ({ErrorCode}): Ocurrió una excepción SQL al eliminar un producto.", exsql.Number);
                    oResp.ErrorCode = exsql.Number;
                    oResp.ErrorMessage = "Error de base de datos, contactar con el administrador del sistema.";
                    oResp.StatusType = "SQL-ERROR";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Backend Error (50100): Ocurrió una excepción en C# al eliminar un producto.");
                oResp.ErrorCode = 50100;
                oResp.ErrorMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio.";
                oResp.StatusType = "BACKEND-ERROR";
            }

            return oResp;
        }
    }
}
