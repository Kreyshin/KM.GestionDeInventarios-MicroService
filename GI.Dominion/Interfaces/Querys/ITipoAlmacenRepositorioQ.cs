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
        public Task<ListResponse<List<TipoAlmacenEN>>> Listar();
        public Task<SingleResponse<TipoAlmacenEN>> BuscarPorID(string id);
    }
}
