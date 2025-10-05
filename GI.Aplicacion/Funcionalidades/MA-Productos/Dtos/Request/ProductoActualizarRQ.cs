using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Request
{
    public class ProductoActualizarRQ
    {
        public string? nombre { set; get; }
        public string? descripcion { set; get; }
        public string? sku { set; get; }
        public int? idCategoria { set; get; }
        public int? idUnidadMedida { set; get; }
        public int? idMarca { set; get; }
        public int? idEstado { set; get; }
    }
}
