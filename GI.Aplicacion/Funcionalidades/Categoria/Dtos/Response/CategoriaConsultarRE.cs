using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.Categoria.Dtos.Response
{
    public class CategoriaConsultarRE
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public bool activo { get; set; }
        public string estado { get; set; } = string.Empty;
    }
}
