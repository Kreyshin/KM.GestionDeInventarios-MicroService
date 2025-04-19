using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request;
using GI.Aplicacion.Funcionalidades.Categoria.Interfacess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GI.Api.Controllers.Maestros
{
    [Route("v1/GestionInventarios/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaCrudCU _categoriaCrudCU;

        public CategoriaController(ICategoriaCrudCU categoriaCrudCU)
        {
            _categoriaCrudCU = categoriaCrudCU;
        }

        #region Querys
        [HttpGet("")]
        public async Task<IActionResult> Consultar(CategoriaConsultarRQ oFiltro)
        {

            var oResult = await _categoriaCrudCU.Consultar(oFiltro);

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
            var oResult = await _categoriaCrudCU.BuscarPorID(id);

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
        public async Task<IActionResult> Crear(CategoriaCrearRQ oRegistro)
        {
            if (oRegistro == null)
            {
                return BadRequest(new { StatusType = "InvalidInput", StatusMessage = "El cuerpo de la peticion no puede ser nulo." });
            }

            var oResult = await _categoriaCrudCU.Crear(oRegistro);

            return oResult.StatusCode switch
            {
                200 => Ok(new { oResult.Data, oResult.StatusType, oResult.StatusMessage }),
                400 => BadRequest(new { oResult.StatusType, oResult.StatusMessage }),
                _ => StatusCode(500, new { oResult.StatusType, oResult.StatusMessage })
            };
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, CategoriaActualizarRQ oRegistro)
        {
            if (oRegistro == null)
            {
                return BadRequest(new { StatusType = "InvalidInput", StatusMessage = "El registro no puede ser nulo." });
            }

            var oResult = await _categoriaCrudCU.Actualizar(id, oRegistro);

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

            var oResult = await _categoriaCrudCU.Eliminar(id);

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
