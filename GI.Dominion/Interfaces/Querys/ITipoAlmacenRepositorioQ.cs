using GI.Dominio.Comunes;
using GI.Dominio.Entidades;

namespace GI.Dominio.Interfaces.Querys
{
    public interface ITipoAlmacenRepositorioQ
    {
        public Task<ListResponse<TipoAlmacenEN>> Consultar(TipoAlmacenEN oFiltros);
        public Task<SingleResponse<TipoAlmacenEN>> BuscarPorID(int id);
    }
}
