using FluentValidation;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.Categoria.Validadores
{
    public class CategoriaActualizarRQValidator : AbstractValidator<CategoriaActualizarRQ>
    {
        public CategoriaActualizarRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' no puede estar vacío.")
                .MaximumLength(300).WithMessage("El campo 'nombre' no puede exceder los 300 caracteres.")
                .When(x => x.nombre != null);
        }
    }
}
