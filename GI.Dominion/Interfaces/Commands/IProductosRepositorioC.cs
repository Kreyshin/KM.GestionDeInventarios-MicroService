using GI.Dominio.Comunes;
using GI.Dominio.Entidades;

namespace GI.Dominio.Interfaces.Commands
{
    public interface IProductosRepositorioC
    {
        public Task<SingleResponse<ProductoEN>> Crear(ProductoEN oRegistro);
        public Task<SingleResponse<ProductoEN>> Actualizar(ProductoEN oRegistro);
        public Task<SingleResponse<int>> Eliminar(int id);
    }
}
