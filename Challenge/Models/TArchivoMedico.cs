using System;
using System.Collections.Generic;

namespace Challenge.Models
{
    /// <summary>
    /// Representa un archivo médico en el sistema, que contiene detalles sobre la evaluación médica de un paciente.
    /// </summary>
    public partial class TArchivoMedico
    {
        /// <summary>
        /// Identificador único del archivo médico.
        /// </summary>
        public int IdArchivoMedico { get; set; }

        /// <summary>
        /// Información relacionada con la audiometría realizada al paciente.
        /// </summary>
        public string? Audiometria { get; set; }

        /// <summary>
        /// Indica si hubo un cambio de puesto en el trabajo del paciente.
        /// </summary>
        public string? CambioPuesto { get; set; }

        /// <summary>
        /// Información sobre los antecedentes médicos de la madre del paciente.
        /// </summary>
        public string? DatosMadre { get; set; }

        /// <summary>
        /// Diagnóstico médico realizado al paciente.
        /// </summary>
        public string? Diagnostico { get; set; }

        /// <summary>
        /// Información sobre los antecedentes médicos de otro familiar del paciente.
        /// </summary>
        public string? DatosOtroFamiliar { get; set; }

        /// <summary>
        /// Información sobre los antecedentes médicos del padre del paciente.
        /// </summary>
        public string? DatosPadre { get; set; }

        /// <summary>
        /// Indica si se realizó la ejecución de micros.
        /// </summary>
        public string? EjectuarMicros { get; set; }

        /// <summary>
        /// Indica si se realizó ejecución de exámenes extra.
        /// </summary>
        public string? EjecutarExtra { get; set; }

        /// <summary>
        /// Información sobre la evaluación de la voz del paciente.
        /// </summary>
        public string? EvaluacionVoz { get; set; }

        /// <summary>
        /// Fecha de baja del archivo médico (si aplica).
        /// </summary>
        public DateOnly? FecBaja { get; set; }

        /// <summary>
        /// Fecha en que el archivo fue ingresado al sistema.
        /// </summary>
        public DateOnly? FecIng { get; set; }

        /// <summary>
        /// Fecha de la última modificación realizada al archivo.
        /// </summary>
        public DateOnly? FecMod { get; set; }

        /// <summary>
        /// Fecha de fin de validez del archivo médico.
        /// </summary>
        public DateOnly? FechaFin { get; set; }

        /// <summary>
        /// Fecha de inicio de la validez del archivo médico.
        /// </summary>
        public DateOnly? FechaInicio { get; set; }

        /// <summary>
        /// Identificador del estado actual del archivo médico.
        /// </summary>
        public int? IdEstado { get; set; }

        /// <summary>
        /// Identificador del tipo de archivo médico.
        /// </summary>
        public int? IdTipoArchivoMedico { get; set; }

        /// <summary>
        /// Indica si el paciente tiene incapacidad laboral.
        /// </summary>
        public string? Incapacidad { get; set; }

        /// <summary>
        /// Detalles de la junta médica realizada al paciente.
        /// </summary>
        public string? JuntaMedica { get; set; }

        /// <summary>
        /// Motivo de baja del archivo médico (si aplica).
        /// </summary>
        public string? MotivoBaja { get; set; }

        /// <summary>
        /// Observaciones generales sobre el archivo médico.
        /// </summary>
        public string? Observaciones { get; set; }

        /// <summary>
        /// Porcentaje de incapacidad declarado por el paciente.
        /// </summary>
        public decimal? PorcentajeIncap { get; set; }

        /// <summary>
        /// Usuario que realizó la baja del archivo médico.
        /// </summary>
        public string? UserBaja { get; set; }

        /// <summary>
        /// Usuario que ingresó el archivo médico al sistema.
        /// </summary>
        public string? UserIng { get; set; }

        /// <summary>
        /// Usuario que realizó la última modificación en el archivo.
        /// </summary>
        public string? UserMod { get; set; }

        /// <summary>
        /// Indica si hubo un cambio en el área de trabajo del paciente.
        /// </summary>
        public string? CambioArea { get; set; }

        /// <summary>
        /// Relación con el estado actual del archivo médico.
        /// </summary>
        public virtual Estado? IdEstadoNavigation { get; set; }

        /// <summary>
        /// Relación con el tipo de archivo médico.
        /// </summary>
        public virtual TipoArchivoMedico? IdTipoArchivoMedicoNavigation { get; set; }
    }
}
