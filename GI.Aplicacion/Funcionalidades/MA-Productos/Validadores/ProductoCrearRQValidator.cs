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
        public ProductoCrearRQValidator()
        {
            RuleFor(x => x.codigo)
                .NotEmpty().WithMessage("El campo 'codigo' es obligatorio.")
                .MaximumLength(20).WithMessage("El campo 'codigo' no puede exceder los 20 caracteres.");

            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' es obligatorio.")
                .MaximumLength(100).WithMessage("El campo 'nombre' no puede exceder los 100 caracteres.");

            RuleFor(x => x.descripcion)
                .MaximumLength(300).WithMessage("El campo 'descripcion' no puede exceder los 300 caracteres.");

            RuleFor(x => x.idCategoria)
                .GreaterThan(0).WithMessage("El campo 'idCategoria' debe ser mayor que 0.");

            RuleFor(x => x.idUnidadMedida)
                .GreaterThan(0).WithMessage("El campo 'idUnidadMedida' debe ser mayor que 0.");

            RuleFor(x => x.idMarca)
                .GreaterThan(0).WithMessage("El campo 'idMarca' debe ser mayor que 0.");

            RuleFor(x => x.sku)
                .NotEmpty().WithMessage("El campo 'sku' es obligatorio.")
                .MaximumLength(50).WithMessage("El campo 'sku' no puede exceder los 50 caracteres.");
        }
    }
}
