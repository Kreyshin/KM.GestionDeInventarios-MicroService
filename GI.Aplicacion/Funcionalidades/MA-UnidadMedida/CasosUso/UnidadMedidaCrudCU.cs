using AutoMapper;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Interfaces;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Commands;
using GI.Dominio.Interfaces.Querys;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.Extensions.Logging;

namespace GI.Aplicacion.Funcionalidades.MA_UnidadMedida.CasosUso
{
    public class UnidadMedidaCrudCU(
          IUnidadMedidaRepositorioQ UnidadMedidaRepositoryQ,
          IUnidadMedidaRepositorioC UnidadMedidaRepositoryC,
          IMapper mapper,
          ILogger<UnidadMedidaCrudCU> logger,
          IAuditoriaHelp audiHelp) : IUnidadMedidaCrudCU
        
    {

        private readonly IUnidadMedidaRepositorioQ _UnidadMedidaRepoQ = UnidadMedidaRepositoryQ;
        private readonly IUnidadMedidaRepositorioC _UnidadMedidaRepoC = UnidadMedidaRepositoryC;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<UnidadMedidaCrudCU> _logger = logger;
        private readonly IAuditoriaHelp _audiHelp = audiHelp;

        public async Task<SingleResponse<UnidadMedidaActualizarRE>> Actualizar(int id, UnidadMedidaActualizarRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var UnidadMedidaEn = _mapper.Map<UnidadMedidaEN>(oRegistro);
                UnidadMedidaEn.ID = id;
                UnidadMedidaEn.C_Usuario_Modificacion = _audiHelp.UserName;
                var oRes = await _UnidadMedidaRepoC.Actualizar(UnidadMedidaEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<UnidadMedidaActualizarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<UnidadMedidaActualizarRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<UnidadMedidaActualizarRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<UnidadMedidaActualizarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar actualizar la UnidadMedida.");
                return new SingleResponse<UnidadMedidaActualizarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<UnidadMedidaBuscarPorIDRE>> BuscarPorID(int id)
        {
            try
            {
                var oRes = await _UnidadMedidaRepoQ.BuscarPorID(id);

                if (oRes.ErrorCode == 0 && oRes.Data != null)
                {
                    return new SingleResponse<UnidadMedidaBuscarPorIDRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<UnidadMedidaBuscarPorIDRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data == null)
                {
                    return new SingleResponse<UnidadMedidaBuscarPorIDRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<UnidadMedidaBuscarPorIDRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar buscar UnidadMedida por ID.");
                return new SingleResponse<UnidadMedidaBuscarPorIDRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<ListResponse<UnidadMedidaConsultarRE>> Consultar(UnidadMedidaConsultarRQ oFiltro)
        {
            if (oFiltro == null)
            {
                throw new ArgumentNullException(nameof(oFiltro));
            }

            try
            {
                var UnidadMedidaEN = _mapper.Map<UnidadMedidaEN>(oFiltro);

                var oRes = await _UnidadMedidaRepoQ.Consultar(UnidadMedidaEN);

                if (oRes.ErrorCode == 0 && oRes.Data.Count() > 0)
                {
                    return new ListResponse<UnidadMedidaConsultarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<List<UnidadMedidaConsultarRE>>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data.Count() == 0)
                {
                    return new ListResponse<UnidadMedidaConsultarRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new ListResponse<UnidadMedidaConsultarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar consultar los UnidadMedidaes.");
                return new ListResponse<UnidadMedidaConsultarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<UnidadMedidaCrearRE>> Crear(UnidadMedidaCrearRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var UnidadMedidaEn = _mapper.Map<UnidadMedidaEN>(oRegistro);
                UnidadMedidaEn.C_Usuario_Creacion = _audiHelp.UserName;
                var oRes = await _UnidadMedidaRepoC.Crear(UnidadMedidaEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<UnidadMedidaCrearRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<UnidadMedidaCrearRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<UnidadMedidaCrearRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<UnidadMedidaCrearRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar crear la UnidadMedida.");
                return new SingleResponse<UnidadMedidaCrearRE>
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
                var oRes = await _UnidadMedidaRepoC.Eliminar(id);

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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar eliminar la UnidadMedida.");
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
