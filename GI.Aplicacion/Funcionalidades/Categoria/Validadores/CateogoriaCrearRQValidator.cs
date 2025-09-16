using FluentValidation;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.Categoria.Validadores
{
    public class CateogoriaCrearRQValidator : AbstractValidator<CategoriaCrearRQ>
    {
        public CateogoriaCrearRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' es obligatorio.")
                .MaximumLength(300).WithMessage("El nombre de la categoría no puede exceder los 100 caracteres.");
        }
    }
}
