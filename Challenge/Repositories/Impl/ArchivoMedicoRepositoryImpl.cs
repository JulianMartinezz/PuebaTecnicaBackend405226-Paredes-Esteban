using Challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Repositories.Impl
{
    /// <summary>
    /// Implementación de la interfaz para archivos médicos que interactúa con la base de datos.
    /// </summary>
    public class ArchivoMedicoRepositoryImpl : ArchivoMedicoRepository
    {
        private readonly ChallengedbContext _context;

        /// <summary>
        /// Crea una nueva instancia de <see cref="ArchivoMedicoRepositoryImpl"/> con el contexto de base de datos especificado.
        /// </summary>
        /// <param name="context">El contexto de base de datos.</param>
        public ArchivoMedicoRepositoryImpl(ChallengedbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea un nuevo archivo médico en la base de datos.
        /// </summary>
        /// <param name="archivoMedico">El archivo médico a crear.</param>
        /// <returns>El archivo médico creado con sus detalles.</returns>
        public async Task<TArchivoMedico> CreateArchivoMedico(TArchivoMedico archivoMedico)
        {
            Estado activo = await _context.Estados.Where(x => x.Nombre == "Activo").FirstOrDefaultAsync();
            archivoMedico.IdEstado = activo.IdEstado;
            archivoMedico.IdEstadoNavigation = null;
            archivoMedico.IdTipoArchivoMedicoNavigation = null;
            await _context.AddAsync(archivoMedico);
            await _context.SaveChangesAsync();
            return archivoMedico;
        }

        /// <summary>
        /// Elimina un archivo médico al actualizar su estado a "Inactivo" y agregando la fecha de baja.
        /// </summary>
        /// <param name="archivo">El archivo médico a eliminar.</param>
        /// <returns>Verdadero si la eliminación fue exitosa; falso en caso contrario.</returns>
        public async Task<bool> DeleteArchivoMedico(TArchivoMedico archivo)
        {
            TArchivoMedico archivoMedico = await _context.TArchivoMedicos.Where(x => x.IdArchivoMedico == archivo.IdArchivoMedico).FirstOrDefaultAsync();
            Estado baja = await _context.Estados.Where(x => x.Nombre == "Inactivo").FirstOrDefaultAsync();
            if (archivoMedico != null && archivo.MotivoBaja != null && baja != null)
            {
                archivoMedico.IdEstado = baja.IdEstado;
                archivoMedico.IdTipoArchivoMedicoNavigation = null;
                archivoMedico.FecBaja = DateOnly.FromDateTime(DateTime.Now);
                archivoMedico.IdEstadoNavigation = null;
                archivoMedico.MotivoBaja = archivo.MotivoBaja;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Obtiene un archivo médico de la base de datos por su identificador.
        /// </summary>
        /// <param name="id">El identificador del archivo médico.</param>
        /// <returns>El archivo médico encontrado o null si no existe.</returns>
        public async Task<TArchivoMedico> GetArchivoMedico(int id)
        {
            TArchivoMedico archivoMedico = await _context.TArchivoMedicos.Where(x => x.IdArchivoMedico == id).FirstOrDefaultAsync();
            return archivoMedico;
        }

        /// <summary>
        /// Obtiene una consulta de archivos médicos, permitiendo filtrado y paginación.
        /// </summary>
        /// <returns>Una consulta de archivos médicos.</returns>
        public IQueryable<TArchivoMedico> GetArchivoMedicos()
        {
            return _context.TArchivoMedicos.AsQueryable();
        }

        /// <summary>
        /// Actualiza un archivo médico en la base de datos con nuevos detalles.
        /// </summary>
        /// <param name="archivo">El archivo médico con los nuevos detalles.</param>
        /// <returns>El archivo médico actualizado, o null si no se encuentra.</returns>
        public async Task<TArchivoMedico> UpdateArchivoMedico(TArchivoMedico archivo)
        {
            TArchivoMedico auxArchivo = await _context.TArchivoMedicos.Where(x => x.IdArchivoMedico == archivo.IdArchivoMedico).FirstOrDefaultAsync();
            if (auxArchivo != null)
            {
                auxArchivo.Audiometria = archivo.Audiometria;
                auxArchivo.CambioPuesto = archivo.CambioPuesto;
                auxArchivo.CambioArea = archivo.CambioArea;
                auxArchivo.Diagnostico = archivo.Diagnostico;
                auxArchivo.DatosMadre = archivo.DatosMadre;
                auxArchivo.DatosPadre = archivo.DatosPadre;
                auxArchivo.DatosOtroFamiliar = archivo.DatosOtroFamiliar;
                auxArchivo.EjectuarMicros = archivo.EjectuarMicros;
                auxArchivo.EjecutarExtra = archivo.EjecutarExtra;
                auxArchivo.JuntaMedica = archivo.JuntaMedica;
                auxArchivo.IdTipoArchivoMedico = archivo.IdTipoArchivoMedico;
                auxArchivo.Incapacidad = archivo.Incapacidad;
                auxArchivo.EvaluacionVoz = archivo.EvaluacionVoz;
                auxArchivo.IdEstadoNavigation = null;
                auxArchivo.IdTipoArchivoMedicoNavigation = null;
                auxArchivo.UserMod = archivo.UserMod;
                auxArchivo.Observaciones = archivo.Observaciones;
                auxArchivo.PorcentajeIncap = archivo.PorcentajeIncap;
                auxArchivo.FecMod = DateOnly.FromDateTime(DateTime.Now);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return auxArchivo;
                }
            }
            return null;
        }
    }
}
