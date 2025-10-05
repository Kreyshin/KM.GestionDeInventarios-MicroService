using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.Validadores
{
    public class AlmacenCrearRQValidator : AbstractValidator<AlmacenCrearRQ>
    {
        public AlmacenCrearRQValidator() {

            RuleFor(x => x.codigo)
                .NotEmpty().WithMessage("El campo 'codigo' es obligatorio.")
                .MaximumLength(10).WithMessage("El campo 'codigo' no puede exceder los 10 caracteres.");
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' es obligatorio.")
                .MaximumLength(50).WithMessage("El campo 'nombre' no puede exceder los 50 caracteres.");
            RuleFor(x => x.direccion)
                .NotEmpty().WithMessage("El campo 'direccion' es obligatorio.")
                .MaximumLength(100).WithMessage("El campo 'direccion' no puede exceder los 100 caracteres.");
            RuleFor(x => x.idTipoAlmacen)
                .GreaterThan(0).WithMessage("El campo 'idTipoAlmacen' debe ser mayor que 0.");
            RuleFor(x => x.ubigeo)
                .NotEmpty().WithMessage("El campo 'ubigeo' es obligatorio.")
                .MaximumLength(6).WithMessage("El campo 'ubigeo' no puede exceder los 6 caracteres.");
            //RuleFor(x => x.latitud)
            //    .NotEmpty().WithMessage("El campo 'latitud' es obligatorio.")
            //    .MaximumLength(20).WithMessage("El campo 'latitud' no puede exceder los 20 caracteres.");
            //RuleFor(x => x.longitud)
            //    .NotEmpty().WithMessage("El campo 'longitud' es obligatorio.")
            //    .MaximumLength(20).WithMessage("El campo 'longitud' no puede exceder los 20 caracteres.");

        }
    }
}
