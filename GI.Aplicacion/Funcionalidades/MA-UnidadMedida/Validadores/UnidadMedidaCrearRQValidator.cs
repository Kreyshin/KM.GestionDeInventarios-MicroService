
using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Validadores
{
    public class UnidadMedidaCrearRQValidator : AbstractValidator<UnidadMedidaCrearRQ>
    {
      public UnidadMedidaCrearRQValidator()
        {
            RuleFor(x => x.codigo)
                .NotEmpty().WithMessage("El campo 'codigo' es obligatorio.")
                .MaximumLength(10).WithMessage("El campo 'Codigo' no puede exceder los 10 caracteres.");
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' es obligatorio.")
                .MaximumLength(100).WithMessage("El campo 'nombre' no puede exceder los 200 caracteres.");
          
        }
    }
}
