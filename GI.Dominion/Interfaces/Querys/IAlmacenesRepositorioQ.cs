using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Interfaces.Querys
{
    public interface IAlmacenesRepositorioQ
    {
        public Task<SingleResponse<AlmacenEN>> BuscarPorID(int id);
        public Task<ListResponse<AlmacenEN>> Consultar(AlmacenEN flt);
    }
}
