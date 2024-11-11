using Challenge.DTO;
using Challenge.Models;
using FluentValidation;

namespace Challenge.Validations
{
    public class ArchivoMedicoCreateDTOValidator : AbstractValidator<ArchivoMedicoCreateDTO>
    {
        private readonly ChallengedbContext _context;

        public ArchivoMedicoCreateDTOValidator(ChallengedbContext context)
        {
            _context = context;

            RuleFor(x => x.IdTipoArchivoMedico)
                .NotEmpty()
                .WithMessage("El Id de Tipo de Archivo Medico es obligatorio.")
                .NotNull()
                .WithMessage("El Id de Tipo Archivo Medico no puede ser nulo.");

            RuleFor(x => x.Diagnostico)
                .NotEmpty()
                .WithMessage("El Diagnostico es obligatorio.")
                .NotNull()
                .WithMessage("El Diagnostico no puede ser nulo.")
                .MaximumLength(100)
                .WithMessage("El Diagnostico no debe exceder los 100 caracteres.");

            RuleFor(x => x.FechaInicio)
                .NotEmpty()
                .WithMessage("La Fecha de Inicio es obligatoria.")
                .Must(date => date <= DateTime.Today)
                .WithMessage("La Fecha de Inicio debe ser hoy o una fecha anterior.")
                .NotNull()
                .WithMessage("La Fecha de Inicio no puede ser nula.");

            RuleFor(x => x.IdEstado)
                .NotEmpty()
                .WithMessage("El Id de Estado es obligatorio.")
                .NotNull()
                .WithMessage("El Id de Estado no puede ser nulo.");

            RuleFor(x => x.UserIng)
                .NotEmpty()
                .WithMessage("El campo User Ing es obligatorio.")
                .NotNull()
                .WithMessage("El campo User Ing no puede ser nulo.");

            RuleFor(x => x.DatosMadre)
                .MaximumLength(2000)
                .WithMessage("Los Datos de la Madre no deben exceder los 2000 caracteres.");

            RuleFor(x => x.DatosPadre)
                .MaximumLength(2000)
                .WithMessage("Los Datos del Padre no deben exceder los 2000 caracteres.");

            RuleFor(x => x.DatosOtroFamiliar)
                .MaximumLength(2000)
                .WithMessage("Los Datos de Otro Familiar no deben exceder los 2000 caracteres.");

            RuleFor(x => x.JuntaMedica)
                .MaximumLength(2000)
                .WithMessage("Los Datos de la Junta Medica no debe exceder los 2000 caracteres.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(2000)
                .WithMessage("Las Observaciones no deben exceder los 2000 caracteres.");

            RuleFor(x => x.CambioArea)
                .Length(2)
                .WithMessage("El Cambio de Area debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El Cambio de Area debe ser 'SI' o 'NO'.");

            RuleFor(x => x.Audiometria)
                .Length(2)
                .WithMessage("La Audiometria debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("La Audiometria debe ser 'SI' o 'NO'.");

            RuleFor(x => x.CambioPuesto)
                .Length(2)
                .WithMessage("El Cambio de Puesto debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El Cambio de Puesto debe ser 'SI' o 'NO'.");

            RuleFor(x => x.EjectuarMicros)
                .Length(2)
                .WithMessage("El campo Ejectuar Micros debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El campo Ejectuar Micros debe ser 'SI' o 'NO'.");

            RuleFor(x => x.EjecutarExtra)
                .Length(2)
                .WithMessage("El campo Ejecutar Extra debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El campo Ejecutar Extra debe ser 'SI' o 'NO'.");

            RuleFor(x => x.EvaluacionVoz)
                .Length(2)
                .WithMessage("La Evaluacion de Voz debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("La Evaluacion de Voz debe ser 'SI' o 'NO'.");

            RuleFor(x => x.Incapacidad)
                .Length(2)
                .WithMessage("El campo Incapacidad debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El campo Incapacidad debe ser 'SI' o 'NO'.");

            RuleFor(x => x.PorcentajeIncap)
                .InclusiveBetween(0, 100)
                .WithMessage("El campo Porcentaje Incap debe estar entre 0 y 100 cuando el campo Incapacidad es igual a 'SI'.")
                .When(x => x.Incapacidad == "SI");

            RuleFor(x => x.Observaciones)
                .NotEmpty()
                .WithMessage("Las Observaciones son obligatorias cuando el campo Cambio de Puesto es 'SI'.")
                .When(x => x.CambioPuesto == "SI");

            RuleFor(x => x.IdTipoArchivoMedico)
                .Must(id => _context.TipoArchivoMedicos.Any(t => t.IdTipoArchivoMedico == id))
                .WithMessage("El Tipo de Archivo Medico debe existir en la base de datos.");
        }
    }
}
