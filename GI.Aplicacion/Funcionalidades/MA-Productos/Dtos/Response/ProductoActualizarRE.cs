using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Response
{
    public class ProductoActualizarRE
    {
        public int id { set; get; }
        public string codigo { set; get; } = string.Empty;
        public string nombre { set; get; } = string.Empty;
        public string descripcion { set; get; } = string.Empty;
        public int idCategoria { set; get; }    
        public string categoria { set; get; } = string.Empty;
        public int idUnidadMedida { set; get; }
        public string unidadMedida { set; get; } = string.Empty;
        public int idMarca { set; get; }
        public string marca { set; get; } = string.Empty;
        public int idEstado { set; get; }
        public string estado { set; get; } = string.Empty;
        public string sku { set; get; } = string.Empty;
    }
}
