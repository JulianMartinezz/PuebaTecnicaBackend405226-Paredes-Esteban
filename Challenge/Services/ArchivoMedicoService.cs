using Challenge.DTO;
using Challenge.Models;
using System.Threading.Tasks;

namespace Challenge.Services
{
    /// <summary>
    /// Interfaz que define metodos para el manejo de Archivos Medicos.
    /// </summary>
    public interface ArchivoMedicoService
    {
        /// <summary>
        /// Obtiene una lista paginada y filtrada de Archivos Medicos.
        /// </summary>
        /// <param name="filterDTO">Objeto filterDTO con los criterios para el filtrado.</param>
        /// <returns>Una respuesta paginada que contiene los archivos filtrados.</returns>
        Task<PageResponse> GetFilterArchivosMedicos(FilterDTO filterDTO);

        /// <summary>
        /// Obtiene un archivo medico por su identificador unico.
        /// </summary>
        /// <param name="id">El identificador del archivo medico a Obtener.</param>
        /// <returns> El archivo medico si se encuentra, o nulo si no se encuentra.</returns>
        Task<TArchivoMedico> GetArchivMedicoById(int id);

        /// <summary>
        /// Crea un nuevo Archivo medico.
        /// </summary>
        /// <param name="createDTO">Los detalles del archivo medico a crear.</param>
        /// <returns>El archivo medico creado.</returns>
        Task<TArchivoMedico> AddArchivoMedico(ArchivoMedicoCreateDTO createDTO);

        /// <summary>
        /// Actualiza un archivo medico existente.
        /// </summary>
        /// <param name="updateDTO">Los detalles del archivo medico a actualizar.</param>
        /// <returns>El archivo medico actualizado.</returns>
        Task<TArchivoMedico> UpdateArchivoMedico(ArchivoMedicoUpdateDTO updateDTO);

        /// <summary>
        /// Borrado Logico de un archivo medico.
        /// </summary>
        /// <param name="deleteDTO">Los detalles del archivo medico a borrar.</param>
        /// <returns>Un booleano que indica si la operacion fue exitosa o no.</returns>
        Task<bool> DeleteArchivoMedico(ArchivoMedicoDeleteDTO deleteDTO);
    }
}
