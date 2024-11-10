using System;
using System.Collections.Generic;

namespace Challenge.Models
{
    /// <summary>
    /// Representa un tipo de archivo médico en el sistema, que categoriza los archivos médicos según su tipo.
    /// </summary>
    public partial class TipoArchivoMedico
    {
        /// <summary>
        /// Identificador único del tipo de archivo médico.
        /// </summary>
        public int IdTipoArchivoMedico { get; set; }

        /// <summary>
        /// Nombre del tipo de archivo médico.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Descripción adicional sobre el tipo de archivo médico.
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Colección de archivos médicos asociados a este tipo.
        /// </summary>
        public virtual ICollection<TArchivoMedico> TArchivoMedicos { get; set; } = new List<TArchivoMedico>();
    }
}
