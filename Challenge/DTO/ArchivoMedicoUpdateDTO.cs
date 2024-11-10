namespace Challenge.DTO
{
    /// <summary>
    /// Clase de Data Transfer Object (DTO) utilizada para actualizar los datos de un archivo médico existente.
    /// Esta clase permite actualizar varios atributos de un archivo médico sin necesidad de modificar directamente la base de datos.
    /// </summary>
    public class ArchivoMedicoUpdateDTO
    {
        /// <summary>
        /// Identificador único del archivo médico que se va a actualizar.
        /// </summary>
        public int IdArchivoMedico { get; set; }

        /// <summary>
        /// Información sobre la audiometría asociada al archivo médico.
        /// </summary>
        public string? Audiometria { get; set; }

        /// <summary>
        /// Información sobre el cambio de puesto de trabajo del paciente.
        /// </summary>
        public string? CambioPuesto { get; set; }

        /// <summary>
        /// Información relacionada a la madre del paciente.
        /// </summary>
        public string? DatosMadre { get; set; }

        /// <summary>
        /// Diagnóstico médico asociado al archivo médico.
        /// </summary>
        public string? Diagnostico { get; set; }

        /// <summary>
        /// Información relacionada a otro familiar del paciente.
        /// </summary>
        public string? DatosOtroFamiliar { get; set; }

        /// <summary>
        /// Información relacionada al padre del paciente.
        /// </summary>
        public string? DatosPadre { get; set; }

        /// <summary>
        /// Información sobre la ejecución de micros en el tratamiento del paciente.
        /// </summary>
        public string? EjectuarMicros { get; set; }

        /// <summary>
        /// Información sobre la ejecución de procedimientos extras en el tratamiento del paciente.
        /// </summary>
        public string? EjecutarExtra { get; set; }

        /// <summary>
        /// Evaluación de la voz del paciente.
        /// </summary>
        public string? EvaluacionVoz { get; set; }

        /// <summary>
        /// Usuario que realiza la modificación del archivo médico.
        /// </summary>
        public string? UserMod { get; set; }

        /// <summary>
        /// Identificador del estado del archivo médico (por ejemplo, "Activo", "Inactivo").
        /// </summary>
        public int? IdEstado { get; set; }

        /// <summary>
        /// Identificador del tipo de archivo médico asociado a este registro.
        /// </summary>
        public int? IdTipoArchivoMedico { get; set; }

        /// <summary>
        /// Información sobre la incapacidad del paciente (si aplica).
        /// </summary>
        public string? Incapacidad { get; set; }

        /// <summary>
        /// Información sobre la junta médica relacionada al paciente.
        /// </summary>
        public string? JuntaMedica { get; set; }

        /// <summary>
        /// Motivo de la baja (si se está desactivando o eliminando el archivo).
        /// </summary>
        public string? MotivoBaja { get; set; }

        /// <summary>
        /// Observaciones adicionales sobre el archivo médico.
        /// </summary>
        public string? Observaciones { get; set; }

        /// <summary>
        /// Porcentaje de incapacidad asignado al paciente (si aplica).
        /// </summary>
        public decimal? PorcentajeIncap { get; set; }

        /// <summary>
        /// Información sobre el cambio de área en el entorno de trabajo del paciente.
        /// </summary>
        public string? CambioArea { get; set; }
    }
}
