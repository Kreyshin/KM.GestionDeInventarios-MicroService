using GI.Dominio.Comunes;
using GI.Dominio.Entidades;

namespace GI.Dominio.Interfaces.Querys
{
    public interface IUnidadMedidaRepositorioQ
    {
        public Task<ListResponse<UnidadMedidaEN>> Consultar(UnidadMedidaEN oFiltros);
        public Task<SingleResponse<UnidadMedidaEN>> BuscarPorID(int id);
    }
}
