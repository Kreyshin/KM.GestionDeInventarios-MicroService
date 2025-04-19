using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request
{
    public class CategoriaActualizarRQ
    {
        public string? nombre { get; set; }
        public bool? activo { get; set; }
    }
}
