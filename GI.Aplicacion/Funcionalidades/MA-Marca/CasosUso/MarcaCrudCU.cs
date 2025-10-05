using AutoMapper;
using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_Marca.Interfaces;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Response;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Commands;
using GI.Dominio.Interfaces.Querys;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GI.Aplicacion.Funcionalidades.MA_Marca.CasosUso
{
    public class MarcaCrudCU(
          IMarcaRepositorioQ MarcaRepositoryQ,
          IMarcaRepositorioC MarcaRepositoryC,
          IMapper mapper,
          ILogger<MarcaCrudCU> logger,
          IAuditoriaHelp audiHelp,
          IValidator<MarcaCrearRQ> validatorCrear
          ) : IMarcaCrudCU
        
    {

        private readonly IMarcaRepositorioQ _MarcaRepoQ = MarcaRepositoryQ;
        private readonly IMarcaRepositorioC _MarcaRepoC = MarcaRepositoryC;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<MarcaCrudCU> _logger = logger;
        private readonly IAuditoriaHelp _audiHelp = audiHelp;
        private readonly IValidator<MarcaCrearRQ> _validatorCrear = validatorCrear;

        public async Task<SingleResponse<MarcaActualizarRE>> Actualizar(int id, MarcaActualizarRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var MarcaEn = _mapper.Map<MarcaEN>(oRegistro);
                MarcaEn.ID = id;
                MarcaEn.C_Usuario_Modificacion = _audiHelp.UserName;
                var oRes = await _MarcaRepoC.Actualizar(MarcaEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<MarcaActualizarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<MarcaActualizarRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<MarcaActualizarRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<MarcaActualizarRE>
                    {
                        StatusCode = 500,
                        Data = null,
                        StatusMessage = oRes.ErrorMessage,
                        StatusType = oRes.StatusType
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar actualizar la Marca.");
                return new SingleResponse<MarcaActualizarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<MarcaBuscarPorIDRE>> BuscarPorID(int id)
        {
            try
            {
                var oRes = await _MarcaRepoQ.BuscarPorID(id);

                if (oRes.ErrorCode == 0 && oRes.Data != null)
                {
                    return new SingleResponse<MarcaBuscarPorIDRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<MarcaBuscarPorIDRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data == null)
                {
                    return new SingleResponse<MarcaBuscarPorIDRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<MarcaBuscarPorIDRE>
                    {
                        StatusCode = 500,
                        Data = null,
                        StatusMessage = oRes.ErrorMessage,
                        StatusType = oRes.StatusType
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar buscar Marca por ID.");
                return new SingleResponse<MarcaBuscarPorIDRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<ListResponse<MarcaConsultarRE>> Consultar( MarcaConsultarRQ oFiltro)
        {
            if (oFiltro == null)
            {
                throw new ArgumentNullException(nameof(oFiltro));
            }

            try
            {
                var MarcaEN = _mapper.Map<MarcaEN>(oFiltro);

                var oRes = await _MarcaRepoQ.Consultar(MarcaEN);

                if (oRes.ErrorCode == 0 && oRes.Data.Count() > 0)
                {
                    return new ListResponse<MarcaConsultarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<List<MarcaConsultarRE>>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data.Count() == 0)
                {
                    return new ListResponse<MarcaConsultarRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new ListResponse<MarcaConsultarRE>
                    {
                        StatusCode = 500,
                        Data = null,
                        StatusMessage = oRes.ErrorMessage,
                        StatusType = oRes.StatusType
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar consultar los Marcaes.");
                return new ListResponse<MarcaConsultarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<MarcaCrearRE>> Crear(MarcaCrearRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            var validationResult = await _validatorCrear.ValidateAsync(oRegistro);
            if (!validationResult.IsValid)
            {
                return new SingleResponse<MarcaCrearRE>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Data = null,
                    StatusType = "VALIDACION",
                    StatusMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }

            try
            {
                var MarcaEn = _mapper.Map<MarcaEN>(oRegistro);
                MarcaEn.C_Usuario_Creacion = _audiHelp.UserName;
                var oRes = await _MarcaRepoC.Crear(MarcaEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<MarcaCrearRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<MarcaCrearRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<MarcaCrearRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<MarcaCrearRE>
                    {
                        StatusCode = 500,
                        Data = null,
                        StatusMessage = oRes.ErrorMessage,
                        StatusType = oRes.StatusType
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar crear la Marca.");
                return new SingleResponse<MarcaCrearRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<bool>> Eliminar(int id)
        {
            try
            {
                var oRes = await _MarcaRepoC.Eliminar(id);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<bool>
                    {
                        StatusCode = 200,
                        Data = true,
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<bool>
                    {
                        StatusCode = 400,
                        Data = false,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<bool>
                    {
                        StatusCode = 500,
                        Data = false,
                        StatusMessage = oRes.ErrorMessage,
                        StatusType = oRes.StatusType
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar eliminar la Marca.");
                return new SingleResponse<bool>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }
    }
}
