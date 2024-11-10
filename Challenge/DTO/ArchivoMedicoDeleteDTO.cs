namespace Challenge.DTO
{
    /// <summary>
    /// Clase de Data Transfer Object (DTO) utilizada para marcar un archivo médico como eliminado (baja).
    /// Esta clase contiene los datos necesarios para registrar el motivo y detalles de la baja de un archivo médico.
    /// </summary>
    public class ArchivoMedicoDeleteDTO
    {
        /// <summary>
        /// Identificador único del archivo médico que se va a dar de baja.
        /// </summary>
        public int IdArchivoMedico { get; set; }

        /// <summary>
        /// Fecha de modificación del archivo, utilizada para actualizar la fecha cuando se realiza la baja.
        /// </summary>
        public DateOnly? FecMod { get; set; }

        /// <summary>
        /// Identificador del estado del archivo médico (por ejemplo, "Inactivo" después de la baja).
        /// </summary>
        public int? IdEstado { get; set; }

        /// <summary>
        /// Motivo de la baja del archivo médico, es decir, por qué se marca como inactivo o eliminado.
        /// </summary>
        public string? MotivoBaja { get; set; }

        /// <summary>
        /// Fecha de inicio de la vigencia del archivo médico, cuando se crea o se inicia.
        /// </summary>
        public DateOnly? FechaInicio { get; set; }

        /// <summary>
        /// Fecha en que termina la vigencia del archivo médico, correspondiente al fin de la baja.
        /// </summary>
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// Usuario que realiza la baja del archivo médico.
        /// </summary>
        public string? UserBaja { get; set; }
    }
}
