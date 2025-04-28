using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Response;
using GI.Dominio.Comunes;

namespace GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Interfaces
{
    public interface ITipoAlmacenCrudCU
    {
        public Task<SingleResponse<TipoAlmacenCrearRE>> Crear(TipoAlmacenCrearRQ tipoAlmacen);
        public Task<SingleResponse<TipoAlmacenActualizarRE>> Actualizar(int id, TipoAlmacenActualizarRQ tipoAlmacen);
        public Task<SingleResponse<bool>> Eliminar(int id);
        public Task<SingleResponse<TipoAlmacenBuscarPorIDRE>> BuscarPorID(int id);
        public Task<ListResponse<TipoAlmacenConsultarRE>> Consultar(TipoAlmacenConsultarRQ filtros);
    }
}
