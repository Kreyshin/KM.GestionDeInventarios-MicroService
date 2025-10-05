using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Validadores
{
    public class TipoAlmacenCrearRQValidator : AbstractValidator<TipoAlmacenCrearRQ>
    {
        public TipoAlmacenCrearRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' es obligatorio.")
                .MaximumLength(10).WithMessage("El campo 'nombre' no puede exceder los 10 caracteres.");
            RuleFor(x => x.descripcion)
                .NotEmpty().WithMessage("El campo 'descripcion' es obligatorio.")
                .MaximumLength(100).WithMessage("El campo 'descripcion' no puede exceder los 100 caracteres.");
            
        }
    }
}
