using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Entidades
{
    public class TipoAlmacenEN
    {
        public int ID { get; set; }
        public string? C_Codigo { get; set; } = null;
        public string? C_Nombre { get; set; }
        public string? C_Descripcion { get; set; }
        public int ID_Estado { get; set; }
        public string C_Usuario_Creacion { get; set; }
        public DateTime? D_Fecha_Creacion { get; set; }
        public string C_Usuario_Modificacion { get; set; }
        public DateTime? D_Fecha_Modificacion { get; set; }

    }
}
