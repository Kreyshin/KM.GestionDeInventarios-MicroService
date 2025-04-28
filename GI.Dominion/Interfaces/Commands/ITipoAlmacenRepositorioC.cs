using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Interfaces.Commands
{
    public interface ITipoAlmacenRepositorioC
    {
        public Task<SingleResponse<TipoAlmacenEN>> Crear(TipoAlmacenEN tipoAlmacen);
        public Task<SingleResponse<TipoAlmacenEN>> Actualizar(TipoAlmacenEN tipoAlmacen);
        public Task<SingleResponse<int>> Eliminar(int id);
    }
}
