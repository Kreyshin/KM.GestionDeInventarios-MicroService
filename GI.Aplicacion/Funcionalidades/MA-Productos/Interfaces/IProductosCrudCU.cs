using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Response;
using GI.Dominio.Comunes;

namespace GI.Aplicacion.Funcionalidades.MA_Productos.Interfaces
{
    public interface IProductosCrudCU
    {
        public Task<SingleResponse<ProductoCrearRE>> Crear(ProductoCrearRQ oRegistro);
        public Task<SingleResponse<ProductoActualizarRE>> Actualizar(int id, ProductoActualizarRQ oRegistro);
        public Task<SingleResponse<bool>> Eliminar(int id);
        public Task<SingleResponse<ProductoBuscarPorIDRE>> BuscarPorID(int id);
        public Task<ListResponse<ProductoConsultarRE>> Consultar(ProductoConsultarRQ oFiltro);
    }
}
