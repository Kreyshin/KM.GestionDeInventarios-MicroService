using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Interfaces.Commands
{
    public interface IMarcaRepositorioC
    {
        public Task<SingleResponse<MarcaEN>> Crear(MarcaEN Marca);
        public Task<SingleResponse<MarcaEN>> Actualizar(MarcaEN Marca);
        public Task<SingleResponse<int>> Eliminar(int id);
    }
}
