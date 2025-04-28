using AutoMapper;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Interfaces;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Commands;
using GI.Dominio.Interfaces.Querys;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.Extensions.Logging;

namespace GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.CasosUso
{
    public class TipoAlmacenCrudCU(
          ITipoAlmacenRepositorioQ TipoAlmacenRepositoryQ,
          ITipoAlmacenRepositorioC TipoAlmacenRepositoryC,
          IMapper mapper,
          ILogger<TipoAlmacenCrudCU> logger,
          IAuditoriaHelp audiHelp) : ITipoAlmacenCrudCU
        
    {

        private readonly ITipoAlmacenRepositorioQ _TipoAlmacenRepoQ = TipoAlmacenRepositoryQ;
        private readonly ITipoAlmacenRepositorioC _TipoAlmacenRepoC = TipoAlmacenRepositoryC;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<TipoAlmacenCrudCU> _logger = logger;
        private readonly IAuditoriaHelp _audiHelp = audiHelp;

        public async Task<SingleResponse<TipoAlmacenActualizarRE>> Actualizar(int id, TipoAlmacenActualizarRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var TipoAlmacenEn = _mapper.Map<TipoAlmacenEN>(oRegistro);
                TipoAlmacenEn.ID = id;
                TipoAlmacenEn.C_Usuario_Modificacion = _audiHelp.UserName;
                var oRes = await _TipoAlmacenRepoC.Actualizar(TipoAlmacenEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<TipoAlmacenActualizarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<TipoAlmacenActualizarRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<TipoAlmacenActualizarRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<TipoAlmacenActualizarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar actualizar la TipoAlmacen.");
                return new SingleResponse<TipoAlmacenActualizarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<TipoAlmacenBuscarPorIDRE>> BuscarPorID(int id)
        {
            try
            {
                var oRes = await _TipoAlmacenRepoQ.BuscarPorID(id);

                if (oRes.ErrorCode == 0 && oRes.Data != null)
                {
                    return new SingleResponse<TipoAlmacenBuscarPorIDRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<TipoAlmacenBuscarPorIDRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data == null)
                {
                    return new SingleResponse<TipoAlmacenBuscarPorIDRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<TipoAlmacenBuscarPorIDRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar buscar TipoAlmacen por ID.");
                return new SingleResponse<TipoAlmacenBuscarPorIDRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<ListResponse<TipoAlmacenConsultarRE>> Consultar(TipoAlmacenConsultarRQ oFiltro)
        {
            if (oFiltro == null)
            {
                throw new ArgumentNullException(nameof(oFiltro));
            }

            try
            {
                var TipoAlmacenEN = _mapper.Map<TipoAlmacenEN>(oFiltro);

                var oRes = await _TipoAlmacenRepoQ.Consultar(TipoAlmacenEN);

                if (oRes.ErrorCode == 0 && oRes.Data.Count() > 0)
                {
                    return new ListResponse<TipoAlmacenConsultarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<List<TipoAlmacenConsultarRE>>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data.Count() == 0)
                {
                    return new ListResponse<TipoAlmacenConsultarRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new ListResponse<TipoAlmacenConsultarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar consultar los TipoAlmacenes.");
                return new ListResponse<TipoAlmacenConsultarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<TipoAlmacenCrearRE>> Crear(TipoAlmacenCrearRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var TipoAlmacenEn = _mapper.Map<TipoAlmacenEN>(oRegistro);
                TipoAlmacenEn.C_Usuario_Creacion = _audiHelp.UserName;
                var oRes = await _TipoAlmacenRepoC.Crear(TipoAlmacenEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<TipoAlmacenCrearRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<TipoAlmacenCrearRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<TipoAlmacenCrearRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<TipoAlmacenCrearRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar crear la TipoAlmacen.");
                return new SingleResponse<TipoAlmacenCrearRE>
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
                var oRes = await _TipoAlmacenRepoC.Eliminar(id);

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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar eliminar la TipoAlmacen.");
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
