using Challenge.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Repositories
{
    /// <summary>
    /// Interfaz que define los métodos de acceso a datos para los registros medicos.
    /// </summary>
    public interface ArchivoMedicoRepository
    {
        /// <summary>
        /// Crea un nuevo registro medico.
        /// </summary>
        /// <param name="archivoMedico">El registro medico a crear.</param>
        /// <returns>El registro medico creado.</returns>
        Task<TArchivoMedico> CreateArchivoMedico(TArchivoMedico archivoMedico);

        /// <summary>
        /// Obtiene un registro medico por su identificador.
        /// </summary>
        /// <param name="id">El identificador del registro medico a obtener.</param>
        /// <returns>El registro medico correspondiente al identificador o null si no se encuentra.</returns>
        Task<TArchivoMedico> GetArchivoMedico(int id);

        /// <summary>
        /// Borrado Logico de un registro medico.
        /// </summary>
        /// <param name="archivo">El registro medico a eliminar.</param>
        /// <returns>Un valor booleano que indica si la eliminación fue exitosa.</returns>
        Task<bool> DeleteArchivoMedico(TArchivoMedico archivo);

        /// <summary>
        /// Actualiza un registro medico existente.
        /// </summary>
        /// <param name="archivo">El registro medico con los detalles actualizados.</param>
        /// <returns>El registro medico actualizado.</returns>
        Task<TArchivoMedico> UpdateArchivoMedico(TArchivoMedico archivo);

        /// <summary>
        /// Obtiene un conjunto de registros medicos como una consulta que permite filtrado y paginación.
        /// </summary>
        /// <returns>Un conjunto de registros medicos como <see cref="IQueryable{TArchivoMedico}"/>.</returns>
        IQueryable<TArchivoMedico> GetArchivoMedicos();
    }
}
