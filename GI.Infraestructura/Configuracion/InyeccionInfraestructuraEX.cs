using GI.Dominio.Interfaces.Commands;
using GI.Dominio.Interfaces.Querys;
using GI.Infraestructura.Persistencia;
using GI.Infraestructura.Repositorios.Commands;
using GI.Infraestructura.Repositorios.Querys;
using Microsoft.Extensions.DependencyInjection;

namespace GI.Infraestructura.Configuracion
{
    public static class InyeccionInfraestructuraEX
    {
        public static IServiceCollection InyeccionInfraestructura(this IServiceCollection services)
        {
            services.AddScoped<DbConexion>();
            services.AddScoped<ICategoriaRepositorioC, CategoriaRepositoryC>();
            services.AddScoped<ICategoriaRepositorioQ, CategoriaRepositoryQ>();
            return services;
        }
    }
}
