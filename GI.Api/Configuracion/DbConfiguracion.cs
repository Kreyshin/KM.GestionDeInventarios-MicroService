using GI.Infraestructura.Persistencia;

namespace GI.Api.Configuracion
{
    public class DbConfiguracion(IConfiguration configuration) : IDbConfiguracion
    {
        public string ConnectionString => configuration.GetConnectionString("DefaultConnection");
    }

}
