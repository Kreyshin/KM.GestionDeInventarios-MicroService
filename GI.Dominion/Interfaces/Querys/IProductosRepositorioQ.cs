using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Interfaces.Querys
{
    public interface IProductosRepositorioQ
    {
        public Task<ListResponse<ProductoEN>> Consultar(ProductoEN oFiltros);
        public Task<SingleResponse<ProductoEN>> BuscarPorID(int Id);
    }
}
