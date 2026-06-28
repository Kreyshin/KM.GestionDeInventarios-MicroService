using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Validadores
{
    public class UnidadMedidaActualizarRQValidator : AbstractValidator<UnidadMedidaActualizarRQ>
    {
        public UnidadMedidaActualizarRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' no puede estar vacío.")
                .MaximumLength(100).WithMessage("El campo 'nombre' no puede exceder los 100 caracteres.")
                .When(x => x.nombre != null);
        }
    }
}
