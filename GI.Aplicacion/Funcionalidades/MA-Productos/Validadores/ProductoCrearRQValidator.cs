using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Productos.Validadores
{
    public class ProductoCrearRQValidator : AbstractValidator<ProductoCrearRQ>
    {
        public ProductoCrearRQValidator() { 
        
            RuleFor(x => x.codigo)
                .NotEmpty().WithMessage("El código es obligatorio.")
                .MaximumLength(20).WithMessage("El código no puede tener más de 20 caracteres.");


        }
    }
}
