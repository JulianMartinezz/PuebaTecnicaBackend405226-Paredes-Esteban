namespace Challenge.DTO
{
    /// <summary>
    /// Clase base para las respuestas de las API, encapsulando los resultados y metadatos de una operación.
    /// </summary>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa o no.
        /// </summary>
        public bool? Success { get; set; }

        /// <summary>
        /// Mensaje que proporciona detalles adicionales sobre la operación.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Contiene los datos asociados a la respuesta de la operación. Este tipo es genérico y puede ser cualquier tipo.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Código de estado de la respuesta (por ejemplo, código HTTP o código de error).
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// Número total de filas o registros retornados, útil en operaciones de paginación.
        /// </summary>
        public int? TotalRows { get; set; }

        /// <summary>
        /// Excepción que ocurrió durante la operación (si existe).
        /// </summary>
        public string? Exception { get; set; }
    }
}
