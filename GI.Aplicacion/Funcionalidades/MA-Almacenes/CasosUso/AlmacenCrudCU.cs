using AutoMapper;
using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Interfaces;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Commands;
using GI.Dominio.Interfaces.Querys;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.CasosUso
{
    public class AlmacenCrudCU(
        IAlmacenesRepositorioQ almacenesRepositorioQ,
        IAlmacenesRepositorioC almacenesRepositorioC,
        IMapper mapper,
        ILogger<AlmacenCrudCU> logger,
        IAuditoriaHelp audiHelp,
        IValidator<AlmacenCrearRQ> validatorCrear
        ) : IAlmacenesCrudCU
    {

        private readonly IAlmacenesRepositorioQ _almacenesRepoQ = almacenesRepositorioQ;
        private readonly IAlmacenesRepositorioC _almacenesRepoC = almacenesRepositorioC;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<AlmacenCrudCU> _logger = logger;
        private readonly IAuditoriaHelp _audiHelp = audiHelp;
        private readonly IValidator<AlmacenCrearRQ> _crearValidator = validatorCrear;

        public async Task<SingleResponse<AlmacenActualizarRE>> Actualizar(int id, AlmacenActualizarRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var AlmacenEn = _mapper.Map<AlmacenEN>(oRegistro);
                AlmacenEn.ID = id;
                AlmacenEn.C_Usuario_Modificacion = _audiHelp.UserName;
                var oRes = await _almacenesRepoC.Actualizar(AlmacenEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<AlmacenActualizarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<AlmacenActualizarRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<AlmacenActualizarRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<AlmacenActualizarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar actualizar el Almacen.");
                return new SingleResponse<AlmacenActualizarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<AlmacenBuscarPorIDRE>> BuscarPorID(int id)
        {
            try
            {
                var oRes = await _almacenesRepoQ.BuscarPorID(id);

                if (oRes.ErrorCode == 0 && oRes.Data != null)
                {
                    return new SingleResponse<AlmacenBuscarPorIDRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<AlmacenBuscarPorIDRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data == null)
                {
                    return new SingleResponse<AlmacenBuscarPorIDRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<AlmacenBuscarPorIDRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar buscar el almacen por ID.");
                return new SingleResponse<AlmacenBuscarPorIDRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<ListResponse<AlmacenConsultarRE>> Consultar(AlmacenConsultarRQ oFiltro)
        {
            if (oFiltro == null)
            {
                throw new ArgumentNullException(nameof(oFiltro));
            }

            try
            {
                var almacenEN = _mapper.Map<AlmacenEN>(oFiltro);

                var oRes = await _almacenesRepoQ.Consultar(almacenEN);

                if (oRes.ErrorCode == 0 && oRes.Data.Count() > 0)
                {
                    return new ListResponse<AlmacenConsultarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<List<AlmacenConsultarRE>>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data.Count() == 0)
                {
                    return new ListResponse<AlmacenConsultarRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new ListResponse<AlmacenConsultarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar consultar los almacenes.");
                return new ListResponse<AlmacenConsultarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<AlmacenCrearRE>> Crear(AlmacenCrearRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            var validationResult = await _crearValidator.ValidateAsync(oRegistro);

            if (!validationResult.IsValid)
            {
                return new SingleResponse<AlmacenCrearRE>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Data = null,
                    StatusType = "VALIDACION",
                    StatusMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }


            try
            {
                var AlmacenEn = _mapper.Map<AlmacenEN>(oRegistro);
                AlmacenEn.C_Usuario_Creacion = _audiHelp.UserName;
                var oRes = await _almacenesRepoC.Crear(AlmacenEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<AlmacenCrearRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<AlmacenCrearRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<AlmacenCrearRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<AlmacenCrearRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar crear el almacen.");
                return new SingleResponse<AlmacenCrearRE>
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
                var oRes = await _almacenesRepoC.Eliminar(id);

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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar eliminar el almacen.");
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
