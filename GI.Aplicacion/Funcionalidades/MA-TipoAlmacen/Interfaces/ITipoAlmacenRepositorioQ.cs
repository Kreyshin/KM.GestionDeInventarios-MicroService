using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using GI.Infraestructura.Persistencia.DTOs;

namespace GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Interfaces
{
    public interface ITipoAlmacenRepositorioQ
    {
        public Task<ListResponse<TipoAlmacenQueryDTO>> Consultar(TipoAlmacenEN oFiltros);
        public Task<SingleResponse<TipoAlmacenEN>> BuscarPorID(int id);
    }
}
