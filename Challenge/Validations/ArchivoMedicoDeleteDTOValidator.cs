using Challenge.DTO;
using FluentValidation;

namespace Challenge.Validations
{
    public class ArchivoMedicoDeleteDTOValidator : AbstractValidator<ArchivoMedicoDeleteDTO>
    {
        public ArchivoMedicoDeleteDTOValidator()
        {
            RuleFor(x => x.IdArchivoMedico)
                .NotEmpty()
                .WithMessage("El IdArchivoMedico es obligatorio.")
                .NotNull()
                .WithMessage("El IdArchivoMedico no puede ser nulo.");

            RuleFor(x => x.IdEstado)
                .NotEmpty()
                .WithMessage("El Estado es obligatorio.")
                .NotNull()
                .WithMessage("El Estado no puede ser nulo.");

            RuleFor(x => x.MotivoBaja)
                .NotEmpty()
                .WithMessage("El Motivo de Baja es obligatorio.")
                .NotNull()
                .WithMessage("El Motivo de Baja no puede ser nulo.");

            RuleFor(x => x.FechaFin)
                .NotEmpty()
                .WithMessage("La Fecha Fin es obligatoria.")
                .NotNull()
                .WithMessage("La Fecha Fin no puede ser nula.");

            RuleFor(x => x.UserBaja)
                .NotEmpty()
                .WithMessage("El User de la Baja es obligatorio.")
                .NotNull()
                .WithMessage("El User de la Baja no puede ser nulo.");

            RuleFor(x => x)
                .Must(x => DateOnly.FromDateTime(x.FechaFin.Value) > x.FechaInicio)
                .WithMessage("La Fecha de Fin debe ser posterior a la Fecha de Inicio.")
                .When(x => x.FechaInicio.HasValue && x.FechaFin.HasValue);
        }
    }
}
