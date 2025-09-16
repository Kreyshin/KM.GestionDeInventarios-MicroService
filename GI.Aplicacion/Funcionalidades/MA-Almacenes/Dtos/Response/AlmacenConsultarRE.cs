using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Response
{
    public class AlmacenConsultarRE
    {
        public int id { set; get; }
        public string codigo { set; get; } = string.Empty;
        public string nombre { set; get; } = string.Empty;
        public string direccion { set; get; } = string.Empty;
        public string tipoAlmacen { set; get; } = string.Empty;
        public string ubigeo { set; get; } = string.Empty;
        public string telefono { set; get; } = string.Empty;
        public string latitud { set; get; } = string.Empty;
        public string longitud { set; get; } = string.Empty;
        public string estado { set; get; } = string.Empty;
    }
}
