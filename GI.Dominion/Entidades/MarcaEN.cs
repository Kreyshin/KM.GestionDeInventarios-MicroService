using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Entidades
{
    public class MarcaEN
    {
        public int ID { get; set; }
        public string C_Nombre { get; set; } = string.Empty;
        public bool? B_Activo { get; set; }
        public string? C_Usuario_Creacion { get; set; }
        public string? C_Usuario_Modificacion { get; set; }


        //EXTRAS
        public string C_Estado { get; set; } = string.Empty;
    }
}
