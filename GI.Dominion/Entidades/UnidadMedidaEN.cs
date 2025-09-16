using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Entidades
{
    public class UnidadMedidaEN
    {
        public int ID { get; set; }
        public string? C_Nombre { get; set; } = string.Empty;
        public string? C_Codigo { get; set; } = string.Empty;
        public bool? B_Activo { get; set; }
        public DateTime F_Fecha_Creacion { get; set; }
        public DateTime F_Fecha_Modificacion { get; set; }
        public string C_Usuario_Creacion { get; set; }
        public string C_Usuario_Modificacion { get; set; }

        public string C_Estado { get; set; } = string.Empty;
    }
}
