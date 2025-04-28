using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Response;
using GI.Dominio.Comunes;

namespace GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Interfaces
{
    public interface IUnidadMedidaCrudCU
    {
        public Task<SingleResponse<UnidadMedidaCrearRE>> Crear(UnidadMedidaCrearRQ UnidadMedida);
        public Task<SingleResponse<UnidadMedidaActualizarRE>> Actualizar(int id, UnidadMedidaActualizarRQ UnidadMedida);
        public Task<SingleResponse<bool>> Eliminar(int id);
        public Task<SingleResponse<UnidadMedidaBuscarPorIDRE>> BuscarPorID(int id);
        public Task<ListResponse<UnidadMedidaConsultarRE>> Consultar(UnidadMedidaConsultarRQ filtros);
    }
}
