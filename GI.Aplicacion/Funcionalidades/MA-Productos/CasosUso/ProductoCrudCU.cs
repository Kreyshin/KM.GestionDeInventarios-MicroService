using AutoMapper;
using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_Productos.Interfaces;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Commands;
using GI.Dominio.Interfaces.Querys;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GI.Aplicacion.Funcionalidades.MA_Productos.CasosUso
{
    public class ProductoCrudCU(
        IProductosRepositorioQ productosRepositorioQ,
        IProductosRepositorioC productosRepositorioC,
        IMapper mapper,
        ILogger<ProductoCrudCU> logger,
        IAuditoriaHelp audiHelp,
        IValidator<ProductoCrearRQ> validatorCrear

        ) : IProductosCrudCU
    {

        private readonly IProductosRepositorioQ _productosRepoQ = productosRepositorioQ;
        private readonly IProductosRepositorioC _productosRepoC = productosRepositorioC;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<ProductoCrudCU> _logger = logger;
        private readonly IAuditoriaHelp _audiHelp = audiHelp;
        private readonly IValidator<ProductoCrearRQ> _validatorCrear = validatorCrear;


        public async Task<SingleResponse<ProductoActualizarRE>> Actualizar(int id, ProductoActualizarRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var productoEN = _mapper.Map<ProductoEN>(oRegistro);
                productoEN.ID = id;
                productoEN.C_Usuario_Modificacion = _audiHelp.UserName;
                var oRes = await _productosRepoC.Actualizar(productoEN);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<ProductoActualizarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<ProductoActualizarRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<ProductoActualizarRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<ProductoActualizarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar actualizar el producto.");
                return new SingleResponse<ProductoActualizarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<ProductoBuscarPorIDRE>> BuscarPorID(int id)
        {
            try
            {
                var oRes = await _productosRepoQ.BuscarPorID(id);

                if (oRes.ErrorCode == 0 && oRes.Data != null)
                {
                    return new SingleResponse<ProductoBuscarPorIDRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<ProductoBuscarPorIDRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data == null)
                {
                    return new SingleResponse<ProductoBuscarPorIDRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<ProductoBuscarPorIDRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar buscar el producto por ID.");
                return new SingleResponse<ProductoBuscarPorIDRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<ListResponse<ProductoConsultarRE>> Consultar(ProductoConsultarRQ oFiltro)
        {
            if (oFiltro == null)
            {
                throw new ArgumentNullException(nameof(oFiltro));
            }

            try
            {
                var productoEN = _mapper.Map<ProductoEN>(oFiltro);

                var oRes = await _productosRepoQ.Consultar(productoEN);

                if (oRes.ErrorCode == 0 && oRes.Data.Count() > 0)
                {
                    return new ListResponse<ProductoConsultarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<List<ProductoConsultarRE>>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data.Count() == 0)
                {
                    return new ListResponse<ProductoConsultarRE>
                    {
                        StatusCode = 204,
                        Data = null!,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new ListResponse<ProductoConsultarRE>
                    {
                        StatusCode = 500,
                        Data = null!,
                        StatusMessage = oRes.ErrorMessage,
                        StatusType = oRes.StatusType
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar consultar los productos.");
                return new ListResponse<ProductoConsultarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<ProductoCrearRE>> Crear(ProductoCrearRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            var validationResult = await _validatorCrear.ValidateAsync(oRegistro);
            if (!validationResult.IsValid)
            {
                return new SingleResponse<ProductoCrearRE>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Data = null,
                    StatusType = "VALIDACION",
                    StatusMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }

            try
            {
                var productoEN = _mapper.Map<ProductoEN>(oRegistro);
                productoEN.C_Usuario_Creacion = _audiHelp.UserName;
                var oRes = await _productosRepoC.Crear(productoEN);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<ProductoCrearRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<ProductoCrearRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<ProductoCrearRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<ProductoCrearRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar crear el producto.");
                return new SingleResponse<ProductoCrearRE>
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
                var oRes = await _productosRepoC.Eliminar(id);

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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar eliminar el producto.");
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
