using Challenge.DTO;
using Challenge.Models;
using FluentValidation;

namespace Challenge.Validations
{
    public class ArchivoMedicoUpdateDTOValidator : AbstractValidator<ArchivoMedicoUpdateDTO>
    {
        private readonly ChallengedbContext _context;

        public ArchivoMedicoUpdateDTOValidator(ChallengedbContext context)
        {
            _context = context;

            RuleFor(x => x.IdArchivoMedico)
                .NotEmpty()
                .WithMessage("El Id del Archivo Medico es obligatorio.")
                .NotNull()
                .WithMessage("El Id del Archivo Medico no puede ser nulo.")
                .Must(idArchivo => _context.TArchivoMedicos.Where(x => x.IdArchivoMedico == idArchivo).FirstOrDefault().IdEstado != 2)
                .WithMessage("No puede actualizar un archivo dado de baja");

            RuleFor(x => x.IdTipoArchivoMedico)
                .NotEmpty()
                .WithMessage("EL Tipo de Archivo Medico es obligatorio.")
                .NotNull()
                .WithMessage("El Tipo de Archivo Medico no puede ser nulo.");

            RuleFor(x => x.Diagnostico)
                .NotEmpty()
                .WithMessage("El Diagnostico es obligatorio.")
                .NotNull()
                .WithMessage("El Diagnostico no puede ser nulo.")
                .MaximumLength(100)
                .WithMessage("El Diagnostico no debe exceder 100 caracteres.");

            RuleFor(x => x.IdEstado)
                .NotEmpty()
                .WithMessage("El Estado es obligatorio.")
                .NotNull()
                .WithMessage("EL Estado no puede ser nulo.");

            RuleFor(x => x.DatosMadre)
                .MaximumLength(2000)
                .WithMessage("Los Datos de la Madre no deben exceder 2000 caracteres.");

            RuleFor(x => x.DatosPadre)
                .MaximumLength(2000)
                .WithMessage("Los Datos del Padre no deben exceder 2000 caracteres.");

            RuleFor(x => x.DatosOtroFamiliar)
                .MaximumLength(2000)
                .WithMessage("Los Datos de Otro Familiar no deben exceder 2000 caracteres.");

            RuleFor(x => x.JuntaMedica)
                .MaximumLength(2000)
                .WithMessage("El campo Junta Medica no debe exceder 2000 caracteres.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(2000)
                .WithMessage("Las Observaciones no deben exceder 2000 caracteres.");

            RuleFor(x => x.CambioArea)
                .Length(2)
                .WithMessage("El campo Cambio de Area debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El campo Cambio de Area debe ser 'SI' o 'NO'.");

            RuleFor(x => x.Audiometria)
                .Length(2)
                .WithMessage("El campo Audiometria debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El campo Audiometria debe ser 'SI' o 'NO'.");

            RuleFor(x => x.CambioPuesto)
                .Length(2)
                .WithMessage("El campo Cambio de Puesto debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El campo Cambio de Puesto debe ser 'SI' o 'NO'.");

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
                .WithMessage("El campo Evaluacion de Voz debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El campo Evaluacion de Voz debe ser 'SI' o 'NO'.");

            RuleFor(x => x.Incapacidad)
                .Length(2)
                .WithMessage("El campo Incapacidad debe tener exactamente 2 caracteres.")
                .Must(value => value == "SI" || value == "NO")
                .WithMessage("El camop Incapacidad debe ser 'SI' o 'NO'.");

            RuleFor(x => x.PorcentajeIncap)
                .InclusiveBetween(0, 100)
                .WithMessage("EL Porcentaje de Incapacidad debe estar entre 0 y 100 cuando el campo Incapacidad es 'SI'.")
                .When(x => x.Incapacidad == "SI");

            RuleFor(x => x.Observaciones)
                .NotEmpty()
                .WithMessage("Las Observaciones son obligatorias cuando el campo CambioPuesto es 'SI'.")
                .When(x => x.CambioPuesto == "SI");

            RuleFor(x => x.IdTipoArchivoMedico)
                .Must(id => _context.TipoArchivoMedicos.Any(t => t.IdTipoArchivoMedico == id))
                .WithMessage("El Tipo de Archivo Medico debe existir en la base de datos.");

            RuleFor(x => x.IdEstado)
                .Must(id => id!=_context.Estados.Where(x => x.Nombre=="Baja").FirstOrDefault().IdEstado)
                .WithMessage("No puede dar de baja el archivo desde una actualización.")
                .Must(id => _context.Estados.Any(e => e.IdEstado == id))
                .WithMessage("El Estado del Archivo Medico debe existir en la base de datos.");

            RuleFor(x => x.UserMod)
                .NotEmpty()
                .WithMessage("El campo user mod es obligatorio")
                .NotNull()
                .WithMessage("El campo user mod no puede ser nulo");
        }
    }
}
