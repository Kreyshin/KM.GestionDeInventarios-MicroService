using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request
{
    public class AlmacenActualizarRQ
    {
        public string? nombre { set; get; }
        public string? direccion { set; get; }
        public int? idTipoAlmacen { set; get; }
        public int? idEstado { set; get; }
        public string? ubigeo { set; get; }
        public string? telefono { set; get; }
        public string? latitud { set; get; }
        public string? longitud { set; get; }
    }
}
