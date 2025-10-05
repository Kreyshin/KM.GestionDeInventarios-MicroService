using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Response;
using GI.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.Interfaces
{
    public interface IAlmacenesCrudCU
    {
        public Task<SingleResponse<AlmacenCrearRE>> Crear(AlmacenCrearRQ almacen);
        public Task<SingleResponse<AlmacenActualizarRE>> Actualizar(int id,AlmacenActualizarRQ oRegistro);
        public Task<SingleResponse<bool>> Eliminar(int id);
        public Task<SingleResponse<AlmacenBuscarPorIDRE>> BuscarPorID(int id);
        public Task<ListResponse<AlmacenConsultarRE>> Consultar(AlmacenConsultarRQ filtros);
    }
}
