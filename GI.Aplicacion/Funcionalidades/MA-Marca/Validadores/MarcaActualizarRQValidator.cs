using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.MA_Marca.Validadores
{
    public class MarcaActualizarRQValidator : AbstractValidator<MarcaActualizarRQ>
    {
        public MarcaActualizarRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' no puede estar vacío.")
                .MaximumLength(100).WithMessage("El campo 'nombre' no puede exceder los 100 caracteres.")
                .When(x => x.nombre != null);
        }
    }
}
