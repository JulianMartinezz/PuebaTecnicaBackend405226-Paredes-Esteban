using System;
using System.Collections.Generic;

namespace Challenge.Models
{
    /// <summary>
    /// Representa un estado en el sistema, que contiene el identificador, nombre y descripción.
    /// Cada estado puede estar relacionado con múltiples archivos médicos.
    /// </summary>
    public partial class Estado
    {
        /// <summary>
        /// Identificador único del estado.
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// Nombre del estado (ej., Activo, Inactivo).
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Descripción adicional del estado.
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Colección de archivos médicos asociados a este estado.
        /// </summary>
        public virtual ICollection<TArchivoMedico> TArchivoMedicos { get; set; } = new List<TArchivoMedico>();
    }
}
