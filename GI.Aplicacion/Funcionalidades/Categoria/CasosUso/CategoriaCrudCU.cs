using AutoMapper;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Response;
using GI.Aplicacion.Funcionalidades.Categoria.Interfacess;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Dominio.Interfaces.Commands;
using GI.Dominio.Interfaces.Querys;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.Categoria.CasosUso
{
    public class CategoriaCrudCU(
        ICategoriaRepositorioQ categoriaRepositoryQ,
        ICategoriaRepositorioC categoriaRepositoryC,
        IMapper mapper, 
        ILogger<CategoriaCrudCU> logger,
        IAuditoriaHelp audiHelp) : ICategoriaCrudCU
    {

        private readonly ICategoriaRepositorioQ _categoriaRepoQ = categoriaRepositoryQ;
        private readonly ICategoriaRepositorioC _categoriaRepoC = categoriaRepositoryC;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CategoriaCrudCU> _logger = logger;
        private readonly IAuditoriaHelp _audiHelp = audiHelp;

        public async Task<SingleResponse<CategoriaActualizarRE>> Actualizar(int id, CategoriaActualizarRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var CategoriaEn = _mapper.Map<CategoriaEN>(oRegistro);
                CategoriaEn.ID = id;
                CategoriaEn.C_Usuario_Modificacion = _audiHelp.UserName;
                var oRes = await _categoriaRepoC.Actualizar(CategoriaEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<CategoriaActualizarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<CategoriaActualizarRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<CategoriaActualizarRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<CategoriaActualizarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar actualizar la Categoria.");
                return new SingleResponse<CategoriaActualizarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<CategoriaBuscarPorIDRE>> BuscarPorID(int id)
        {         
            try
            {
                var oRes = await _categoriaRepoQ.BuscarPorID(id);

                if (oRes.ErrorCode == 0 && oRes.Data != null)
                {
                    return new SingleResponse<CategoriaBuscarPorIDRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<CategoriaBuscarPorIDRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data == null)
                {
                    return new SingleResponse<CategoriaBuscarPorIDRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<CategoriaBuscarPorIDRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar buscar categoria por ID.");
                return new SingleResponse<CategoriaBuscarPorIDRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<ListResponse<CategoriaConsultarRE>> Consultar(CategoriaConsultarRQ oFiltro)
        {
            if (oFiltro == null)
            {
                throw new ArgumentNullException(nameof(oFiltro));
            }

            try
            {
                var categoriaEN = _mapper.Map<CategoriaEN>(oFiltro);

                var oRes = await _categoriaRepoQ.Consultar(categoriaEN);

                if (oRes.ErrorCode == 0 && oRes.Data.Count() > 0)
                {
                    return new ListResponse<CategoriaConsultarRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<List<CategoriaConsultarRE>>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 0 && oRes.Data.Count() == 0)
                {
                    return new ListResponse<CategoriaConsultarRE>
                    {
                        StatusCode = 204,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new ListResponse<CategoriaConsultarRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar consultar los categoriaes.");
                return new ListResponse<CategoriaConsultarRE>
                {
                    StatusCode = 500,
                    StatusType = "BACKEND-ERROR",
                    StatusMessage = "Error de BackEnd, comunicarse con el encargado de este microservicio."
                };
            }
        }

        public async Task<SingleResponse<CategoriaCrearRE>> Crear(CategoriaCrearRQ oRegistro)
        {
            if (oRegistro == null)
            {
                throw new ArgumentNullException(nameof(oRegistro));
            }

            try
            {
                var CategoriaEn = _mapper.Map<CategoriaEN>(oRegistro);
                CategoriaEn.C_Usuario_Creacion = _audiHelp.UserName;
                var oRes = await _categoriaRepoC.Crear(CategoriaEn);

                if (oRes.ErrorCode == 0)
                {
                    return new SingleResponse<CategoriaCrearRE>
                    {
                        StatusCode = 200,
                        Data = _mapper.Map<CategoriaCrearRE>(oRes.Data),
                        StatusType = "ÉXITO"
                    };
                }
                else if (oRes.ErrorCode == 50001)
                {
                    return new SingleResponse<CategoriaCrearRE>
                    {
                        StatusCode = 400,
                        Data = null,
                        StatusMessage = oRes.StatusMessage,
                        StatusType = oRes.StatusType
                    };
                }
                else
                {
                    return new SingleResponse<CategoriaCrearRE>
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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar crear la Categoria.");
                return new SingleResponse<CategoriaCrearRE>
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
                var oRes = await _categoriaRepoC.Eliminar(id);

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
                _logger.LogError(ex, $"{50200}: Ocurrio un exepcion(c#) al intentar eliminar la Categoria.");
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
