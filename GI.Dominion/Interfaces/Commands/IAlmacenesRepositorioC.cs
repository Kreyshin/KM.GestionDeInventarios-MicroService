using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Interfaces.Commands
{
    public interface IAlmacenesRepositorioC
    {
        public Task<SingleResponse<AlmacenEN>> Crear(AlmacenEN oAlmacen);
        public Task<SingleResponse<AlmacenEN>> Actualizar(AlmacenEN oAlmacen);
        public Task<SingleResponse<int>> Eliminar(int id);
    }
}
