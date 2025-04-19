using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request
{
    public class CategoriaConsultarRQ
    {
        public string nombre { set;get; } = string.Empty;
        public string estado { set; get; } = "TOD";
    }
}
