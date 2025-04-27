using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.TipoAlmacen.Dtos.Request
{
    public class TipoAlmacenConsultarRQ
    {
        public string? nombre { set; get; }
        public string? descripcion { set; get; }
        public string? estado { set; get; }

    }
}
