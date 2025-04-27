using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Interfaces.Querys
{
    public interface ITipoAlmacenRepositorioQ
    {
        public Task<ListResponse<List<TipoAlmacenEN>>> Consultar(TipoAlmacenEN oFiltros);
        public Task<SingleResponse<TipoAlmacenEN>> BuscarPorID(int id);
    }
}
