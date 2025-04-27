using GI.Aplicacion.Funcionalidades.Categoria.CasosUso;
using GI.Aplicacion.Funcionalidades.Categoria.Interfacess;
using GI.Aplicacion.Funcionalidades.Categoria.Mappers;
using GI.Aplicacion.Funcionalidades.TipoAlmacen.CasosUso;
using GI.Aplicacion.Funcionalidades.TipoAlmacen.Interfaces;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                   typeof(CategoriaCrudProfileAM).Assembly
               );
            return services;
        }
    }
}
