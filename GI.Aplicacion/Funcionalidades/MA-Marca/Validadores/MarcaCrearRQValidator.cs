using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.MA_Marca.Validadores
{
    public class MarcaCrearRQValidator : AbstractValidator<MarcaCrearRQ>
    {
        public MarcaCrearRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' es obligatorio.")
                .MaximumLength(100).WithMessage("El campo 'nombre' no puede exceder los 100 caracteres.");
        }
    }
}
