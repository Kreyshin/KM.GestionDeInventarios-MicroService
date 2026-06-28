using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.Validadores
{
    public class AlmacenActualizarRQValidator : AbstractValidator<AlmacenActualizarRQ>
    {
        public AlmacenActualizarRQValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El campo 'nombre' no puede estar vacío.")
                .MaximumLength(50).WithMessage("El campo 'nombre' no puede exceder los 50 caracteres.")
                .When(x => x.nombre != null);

            RuleFor(x => x.direccion)
                .NotEmpty().WithMessage("El campo 'direccion' no puede estar vacío.")
                .MaximumLength(100).WithMessage("El campo 'direccion' no puede exceder los 100 caracteres.")
                .When(x => x.direccion != null);

            RuleFor(x => x.idTipoAlmacen)
                .GreaterThan(0).WithMessage("El campo 'idTipoAlmacen' debe ser mayor que 0.")
                .When(x => x.idTipoAlmacen != null);

            RuleFor(x => x.ubigeo)
                .NotEmpty().WithMessage("El campo 'ubigeo' no puede estar vacío.")
                .MaximumLength(6).WithMessage("El campo 'ubigeo' no puede exceder los 6 caracteres.")
                .When(x => x.ubigeo != null);
        }
    }
}
