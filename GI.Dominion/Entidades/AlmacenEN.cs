using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Entidades
{
    public class AlmacenEN
    {
        public int ID { get;set; }
        public string C_Codigo { get; set; } = string.Empty;
        public string C_Nombre { get; set; } = string.Empty;
        public string C_Direccion { get; set; } = string.Empty;
        public int ID_TipoAlmacen { get; set; } 
        public int ID_Estado { get; set; }
        public string C_Ubigeo { get; set; } = string.Empty;
        public string C_Telefono { get; set; } = string.Empty;
        public string C_Latitud { get; set; } = string.Empty;
        public string C_Longitud { get; set; } = string.Empty;
        public string C_UUID { get; set; } = string.Empty;

        public string? C_Usuario_Creacion { get; set; }
        public string? C_Usuario_Modificacion { get; set; }

        //Adicionales
        public string? C_TipoAlmacen { get; set; }
        public string? C_Estado { get; set; }
    }
}
