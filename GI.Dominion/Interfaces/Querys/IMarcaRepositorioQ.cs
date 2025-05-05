using GI.Dominio.Comunes;
using GI.Dominio.Entidades;

namespace GI.Dominio.Interfaces.Querys
{
    public interface IMarcaRepositorioQ
    {
        public Task<ListResponse<MarcaEN>> Consultar(MarcaEN oFiltros);
        public Task<SingleResponse<MarcaEN>> BuscarPorID(int id);
    }
}
