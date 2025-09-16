using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request
{
    public class AlmacenConsultarRQ
    {
        public string? codigo { set; get; }
        public string? nombre { set; get; }
        public string? direccion { set; get; }
        public int? idTipoAlmacen { set; get; }
        public string? ubigeo { set; get; }
        public int? idEstado { set; get; }
    }
}
