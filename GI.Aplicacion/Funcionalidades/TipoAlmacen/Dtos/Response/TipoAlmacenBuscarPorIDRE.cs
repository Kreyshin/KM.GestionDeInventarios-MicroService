using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.TipoAlmacen.Dtos.Response
{
    public class TipoAlmacenBuscarPorIDRE
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public string estado { get; set; }
    }
}
