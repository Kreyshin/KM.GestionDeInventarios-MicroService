using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Infraestructura.Persistencia.DTOs
{
    public class TipoAlmacenQueryDTO
    {
        public int ID { get; set; }
        public string C_Codigo { get; set; } = string.Empty;
        public string C_Nombre { get; set; } = string.Empty;
        public string C_Descripcion { get; set; } = string.Empty;
        public int ID_Estado { get; set; }
        public string C_Estado { get; set; } = string.Empty;
    }
}
