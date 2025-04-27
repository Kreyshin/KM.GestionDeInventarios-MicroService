using GI.Aplicacion.Funcionalidades.TipoAlmacen.Dtos.Request;
using GI.Aplicacion.Funcionalidades.TipoAlmacen.Dtos.Response;
using GI.Dominio.Comunes;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.TipoAlmacen.Interfaces
{
    public interface ITipoAlmacenCrudCU
    {
        public Task<SingleResponse<TipoAlmacenCrearRE>> Crear(TipoAlmacenCrearRQ tipoAlmacen);
        public Task<SingleResponse<TipoAlmacenActualizarRE>> Actualizar(int id, TipoAlmacenActualizarRQ tipoAlmacen);
        public Task<SingleResponse<bool>> Eliminar(int id);
        public Task<SingleResponse<TipoAlmacenBuscarPorIDRE>> BuscarPorID(int id);
        public Task<ListResponse<TipoAlmacenConsultarRE>> Consultar(TipoAlmacenConsultarRQ filtros);
    }
}
