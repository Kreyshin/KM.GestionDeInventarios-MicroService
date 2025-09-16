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
            services.AddScoped<ITipoAlmacenRepositorioQ, TipoAlmacenRepositoryQ>();
            services.AddScoped<ITipoAlmacenRepositorioC, TipoAlmacenRepositoryC>();
            services.AddScoped<IUnidadMedidaRepositorioQ, UnidadMedidaRepositoryQ>();
            services.AddScoped<IUnidadMedidaRepositorioC, UnidadMedidaRepositoryC>();
            services.AddScoped<IMarcaRepositorioQ, MarcaRepositoryQ>();
            services.AddScoped<IMarcaRepositorioC, MarcaRepositoryC>();
            services.AddScoped<IAlmacenesRepositorioC, AlmacenesRepositoryC>();
            services.AddScoped<IAlmacenesRepositorioQ, AlmacenesRepositoryQ>();
            return services;
        }
    }
}
