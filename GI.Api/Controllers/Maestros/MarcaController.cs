using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Marca.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GI.Api.Controllers.Maestros
{
    [Route("v1/GestionInventarios/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaCrudCU _MarcaCrudCU;

        public MarcaController(IMarcaCrudCU MarcaCrudCU)
        {
            _MarcaCrudCU = MarcaCrudCU;
        }

        #region Querys
        [HttpGet("")]
        public async Task<IActionResult> Consultar(MarcaConsultarRQ oFiltro)
        {

            var oResult = await _MarcaCrudCU.Consultar(oFiltro);

            return oResult.StatusCode switch
            {
                200 => Ok(new { oResult.Data, oResult.StatusType, oResult.StatusMessage }),
                204 => NoContent(),               
                _ => StatusCode(500, new { oResult.StatusMessage })
            };
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPorID(int id)
        {
            var oResult = await _MarcaCrudCU.BuscarPorID(id);

            return oResult.StatusCode switch
            {
                200 => Ok(new { oResult.Data, oResult.StatusType, oResult.StatusMessage }),
                204 => NoContent(),
                _ => StatusCode(500, new { oResult.StatusMessage })
            };
        }
        #endregion

        #region Commands

        [HttpPost("")]
        public async Task<IActionResult> Crear(MarcaCrearRQ oRegistro)
        {
            if (oRegistro == null)
            {
                return BadRequest(new { StatusType = "InvalidInput", StatusMessage = "El cuerpo de la peticion no puede ser nulo." });
            }

            var oResult = await _MarcaCrudCU.Crear(oRegistro);

            return oResult.StatusCode switch
            {
                200 => Ok(new { oResult.Data, oResult.StatusType, oResult.StatusMessage }),
                400 => BadRequest(new { oResult.StatusType, oResult.StatusMessage }),
                _ => StatusCode(500, new { oResult.StatusType, oResult.StatusMessage })
            };
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, MarcaActualizarRQ oRegistro)
        {
            if (oRegistro == null)
            {
                return BadRequest(new { StatusType = "InvalidInput", StatusMessage = "El registro no puede ser nulo." });
            }

            var oResult = await _MarcaCrudCU.Actualizar(id, oRegistro);

            return oResult.StatusCode switch
            {
                200 => Ok(new { oResult.Data, oResult.StatusType, oResult.StatusMessage }),
                400 => BadRequest(new { oResult.StatusType, oResult.StatusMessage }),
                _ => StatusCode(500, new { oResult.StatusMessage })
            };
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {

            var oResult = await _MarcaCrudCU.Eliminar(id);

            return oResult.StatusCode switch
            {
                200 => Ok(new { oResult.Data, oResult.StatusType, oResult.StatusMessage }),
                400 => BadRequest(new { oResult.StatusType, oResult.StatusMessage }),
                _ => StatusCode(500, new { oResult.StatusMessage })
            };

        }

        #endregion
    }
}
