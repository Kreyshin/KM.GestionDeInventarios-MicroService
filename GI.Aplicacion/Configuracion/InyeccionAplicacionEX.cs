using GI.Aplicacion.Funcionalidades.Categoria.CasosUso;
using GI.Aplicacion.Funcionalidades.Categoria.Interfacess;
using GI.Aplicacion.Funcionalidades.Categoria.Mappers;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.CasosUso;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Interfaces;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Mappers;
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


            services.AddAutoMapper(
                   typeof(CategoriaCrudProfileAM).Assembly,
                   typeof(TipoAlmacenCrudProfileAM).Assembly
               );
            return services;
        }
    }
}
