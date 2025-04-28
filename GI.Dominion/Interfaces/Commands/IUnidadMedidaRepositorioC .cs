using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Interfaces.Commands
{
    public interface IUnidadMedidaRepositorioC
    {
        public Task<SingleResponse<UnidadMedidaEN>> Crear(UnidadMedidaEN UnidadMedida);
        public Task<SingleResponse<UnidadMedidaEN>> Actualizar(UnidadMedidaEN UnidadMedida);
        public Task<SingleResponse<int>> Eliminar(int id);
    }
}
