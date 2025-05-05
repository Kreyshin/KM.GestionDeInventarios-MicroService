using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Response;
using GI.Dominio.Comunes;

namespace GI.Aplicacion.Funcionalidades.MA_Marca.Interfaces
{
    public interface IMarcaCrudCU
    {
        public Task<SingleResponse<MarcaCrearRE>> Crear(MarcaCrearRQ Marca);
        public Task<SingleResponse<MarcaActualizarRE>> Actualizar(int id, MarcaActualizarRQ Marca);
        public Task<SingleResponse<bool>> Eliminar(int id);
        public Task<SingleResponse<MarcaBuscarPorIDRE>> BuscarPorID(int id);
        public Task<ListResponse<MarcaConsultarRE>> Consultar(MarcaConsultarRQ filtros);
    }
}
