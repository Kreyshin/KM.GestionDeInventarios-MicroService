using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Dominio.Entidades
{
    public class ProductoEN
    {
        public int ID { get; set; }
        public string C_Codigo { get; set; } = string.Empty;
        public string C_Nombre { get; set; } = string.Empty;
        public string C_Descripcion { get; set; } = string.Empty;
        public int ID_Categoria { get; set; }
        public int ID_UnidadMedida { get; set; }
        public int ID_Marca { get; set; }
        public int ID_Estado { get; set; }
        public string C_SKU { get; set; } = string.Empty;
        public string C_Usuario_Creacion { get; set; } = string.Empty;
        public string C_Usuario_Modificacion { get; set; } = string.Empty;

        // Propiedades Adicionales
        public string C_Categoria { get; set; } = string.Empty;
        public string C_UnidadMedida { get; set; } = string.Empty;
        public string C_Marca { get; set; } = string.Empty;
        public string C_Estado { get; set; } = string.Empty;

    }
}
