using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Validadores
{
    public class TipoAlmacenActualizarRQValidator : AbstractValidator<TipoAlmacenActualizarRQ>
    {
        public TipoAlmacenActualizarRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' no puede estar vacío.")
                .MaximumLength(10).WithMessage("El campo 'nombre' no puede exceder los 10 caracteres.")
                .When(x => x.nombre != null);

            RuleFor(x => x.descripcion)
                .NotEmpty().WithMessage("El campo 'descripcion' no puede estar vacío.")
                .MaximumLength(100).WithMessage("El campo 'descripcion' no puede exceder los 100 caracteres.")
                .When(x => x.descripcion != null);
        }
    }
}
