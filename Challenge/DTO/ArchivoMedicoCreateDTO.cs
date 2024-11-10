namespace Challenge.DTO
{
    /// <summary>
    /// Clase de Data Transfer Object (DTO) utilizada para crear un nuevo archivo médico en el sistema.
    /// Esta clase contiene los datos necesarios para la creación de un archivo médico.
    /// </summary>
    public class ArchivoMedicoCreateDTO
    {
        /// <summary>
        /// Identificador único del archivo médico (generalmente generado automáticamente por la base de datos).
        /// </summary>
        public int IdArchivoMedico { get; set; }

        /// <summary>
        /// Resultado de la audiometría asociada al archivo médico.
        /// </summary>
        public string? Audiometria { get; set; }

        /// <summary>
        /// Indica si ha habido un cambio de puesto para el paciente.
        /// </summary>
        public string? CambioPuesto { get; set; }

        /// <summary>
        /// Información sobre la madre del paciente, si es relevante para el archivo médico.
        /// </summary>
        public string? DatosMadre { get; set; }

        /// <summary>
        /// Diagnóstico médico relacionado con el archivo.
        /// </summary>
        public string? Diagnostico { get; set; }

        /// <summary>
        /// Información sobre otros familiares del paciente que puedan ser relevantes para el archivo.
        /// </summary>
        public string? DatosOtroFamiliar { get; set; }

        /// <summary>
        /// Información sobre el padre del paciente.
        /// </summary>
        public string? DatosPadre { get; set; }

        /// <summary>
        /// Si se ejecutaron micros en el tratamiento o diagnóstico del paciente.
        /// </summary>
        public string? EjectuarMicros { get; set; }

        /// <summary>
        /// Indica si se realizaron procedimientos adicionales al tratamiento regular.
        /// </summary>
        public string? EjecutarExtra { get; set; }

        /// <summary>
        /// Evaluación de la voz del paciente, si se realizó.
        /// </summary>
        public string? EvaluacionVoz { get; set; }

        /// <summary>
        /// Fecha en la que comenzó el tratamiento o registro del archivo médico.
        /// </summary>
        public DateTime? FechaInicio { get; set; }

        /// <summary>
        /// Identificador del estado del archivo médico (activo, inactivo, etc.).
        /// </summary>
        public int? IdEstado { get; set; }

        /// <summary>
        /// Identificador del tipo de archivo médico (radiografía, análisis de sangre, etc.).
        /// </summary>
        public int? IdTipoArchivoMedico { get; set; }

        /// <summary>
        /// Información sobre la incapacidad relacionada con el paciente, si aplica.
        /// </summary>
        public string? Incapacidad { get; set; }

        /// <summary>
        /// Detalles de la junta médica relacionada con el paciente, si aplica.
        /// </summary>
        public string? JuntaMedica { get; set; }

        /// <summary>
        /// Motivo de baja o de finalización del archivo médico.
        /// </summary>
        public string? MotivoBaja { get; set; }

        /// <summary>
        /// Observaciones adicionales sobre el archivo médico.
        /// </summary>
        public string? Observaciones { get; set; }

        /// <summary>
        /// Usuario que registró el archivo médico.
        /// </summary>
        public string? UserIng { get; set; }

        /// <summary>
        /// Porcentaje de incapacidad, si aplica para el paciente.
        /// </summary>
        public decimal? PorcentajeIncap { get; set; }

        /// <summary>
        /// Información sobre el cambio de área relacionado con el archivo médico.
        /// </summary>
        public string? CambioArea { get; set; }
    }
}
