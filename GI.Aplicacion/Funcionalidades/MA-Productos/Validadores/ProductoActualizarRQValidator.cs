using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.MA_Productos.Validadores
{
    public class ProductoActualizarRQValidator : AbstractValidator<ProductoActualizarRQ>
    {
        public ProductoActualizarRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' no puede estar vacío.")
                .MaximumLength(100).WithMessage("El campo 'nombre' no puede exceder los 100 caracteres.")
                .When(x => x.nombre != null);

            RuleFor(x => x.descripcion)
                .MaximumLength(300).WithMessage("El campo 'descripcion' no puede exceder los 300 caracteres.")
                .When(x => x.descripcion != null);

            RuleFor(x => x.sku)
                .NotEmpty().WithMessage("El campo 'sku' no puede estar vacío.")
                .MaximumLength(50).WithMessage("El campo 'sku' no puede exceder los 50 caracteres.")
                .When(x => x.sku != null);

            RuleFor(x => x.idCategoria)
                .GreaterThan(0).WithMessage("El campo 'idCategoria' debe ser mayor que 0.")
                .When(x => x.idCategoria != null);

            RuleFor(x => x.idUnidadMedida)
                .GreaterThan(0).WithMessage("El campo 'idUnidadMedida' debe ser mayor que 0.")
                .When(x => x.idUnidadMedida != null);

            RuleFor(x => x.idMarca)
                .GreaterThan(0).WithMessage("El campo 'idMarca' debe ser mayor que 0.")
                .When(x => x.idMarca != null);

            RuleFor(x => x.idEstado)
                .GreaterThan(0).WithMessage("El campo 'idEstado' debe ser mayor que 0.")
                .When(x => x.idEstado != null);
        }
    }
}
