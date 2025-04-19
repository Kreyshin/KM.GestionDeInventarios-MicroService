using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Interfaces.Commands
{
    public interface ICategoriaRepositorioC
    {
        public Task<SingleResponse<CategoriaEN>> Crear(CategoriaEN oCategoria);
        public Task<SingleResponse<CategoriaEN>> Actualizar(CategoriaEN oCategoria);
        public Task<SingleResponse<int>> Eliminar(int id);
    }
}
