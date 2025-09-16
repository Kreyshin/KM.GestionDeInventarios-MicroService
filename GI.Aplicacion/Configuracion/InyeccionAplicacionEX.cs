using FluentValidation;
using GI.Aplicacion.Funcionalidades.Categoria.CasosUso;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request;
using GI.Aplicacion.Funcionalidades.Categoria.Interfacess;
using GI.Aplicacion.Funcionalidades.Categoria.Mappers;
using GI.Aplicacion.Funcionalidades.Categoria.Validadores;
using GI.Aplicacion.Funcionalidades.MA_Marca.CasosUso;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Marca.Interfaces;
using GI.Aplicacion.Funcionalidades.MA_Marca.Mappers;
using GI.Aplicacion.Funcionalidades.MA_Marca.Validadores;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.CasosUso;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Interfaces;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Mappers;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Validadores;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.CasosUso;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Interfaces;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Mappers;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Validadores;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.Extensions.DependencyInjection;

namespace GI.Aplicacion.Configuracion
{
    public static class InyeccionAplicacionEX
    {
        public static IServiceCollection InyeccionAplicacion(this IServiceCollection services)
        {
            services.AddScoped<IAuditoriaHelp, AuditoriaHelp>();
            services.AddSingleton<IJwtService, JwtService>();
            services.AddScoped<ICategoriaCrudCU, CategoriaCrudCU>();
            services.AddScoped<ITipoAlmacenCrudCU, TipoAlmacenCrudCU>();
            services.AddScoped<IUnidadMedidaCrudCU, UnidadMedidaCrudCU>();
            services.AddScoped<IMarcaCrudCU, MarcaCrudCU>();
            services.AddScoped<IValidator<UnidadMedidaCrearRQ>, UnidadMedidaCrearRQValidator>();
            services.AddScoped<IValidator<CategoriaCrearRQ>, CateogoriaCrearRQValidator>();
            services.AddScoped<IValidator<MarcaCrearRQ>, MarcaCrearRQValidator>();
            services.AddScoped<IValidator<TipoAlmacenCrearRQ>, TipoAlmacenCrearRQValidator>();

            services.AddAutoMapper(
                   typeof(CategoriaCrudProfileAM).Assembly,
                   typeof(TipoAlmacenCrudProfileAM).Assembly,
                   typeof(UnidadMedidaCrudProfileAM).Assembly,
                   typeof(MarcaCrudProfileAM).Assembly
               );
            return services;
        }
    }
}
