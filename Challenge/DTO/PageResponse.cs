using Challenge.Models;

namespace Challenge.DTO
{
    /// <summary>
    /// DTO utilizado para manejar la respuesta de una consulta paginada.
    /// </summary>
    public class PageResponse
    {
        /// <summary>
        /// Número de la página solicitada (actual).
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Número de elementos por página.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Lista de archivos médicos (o cualquier otro tipo de datos) en la página solicitada.
        /// </summary>
        public List<TArchivoMedico>? Archivos { get; set; }

        /// <summary>
        /// Número total de registros disponibles en la base de datos.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
