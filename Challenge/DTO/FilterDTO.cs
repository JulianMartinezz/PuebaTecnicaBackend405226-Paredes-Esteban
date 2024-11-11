namespace Challenge.DTO
{
    /// <summary>
    /// DTO utilizado para aplicar filtros a una consulta con soporte de paginación.
    /// </summary>
    public class FilterDTO
    {
        /// <summary>
        /// Número de la página actual (para paginación).
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Número de elementos por página (para paginación).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Filtro de fecha de fin para los registros (opcional).
        /// </summary>
        public DateOnly? FechaFin { get; set; }

        /// <summary>
        /// Filtro de fecha de inicio para los registros (opcional).
        /// </summary>
        public DateOnly? FechaInicio { get; set; }

        /// <summary>
        /// Filtro por el ID de estado (opcional).
        /// </summary>
        public int? IdEstado { get; set; }

        /// <summary>
        /// Filtro por el ID de tipo de archivo médico (opcional).
        /// </summary>
        public int? IdTipoArchivoMedico { get; set; }
    }
}
