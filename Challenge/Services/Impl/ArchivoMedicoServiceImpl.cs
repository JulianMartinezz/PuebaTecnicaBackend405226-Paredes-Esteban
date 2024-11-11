using AutoMapper;
using Challenge.DTO;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Services.Impl
{
    /// <summary>
    /// Implementación de la Interfaz del servicio para el manejo de Archivos Medicos.
    /// </summary>
    public class ArchivoMedicoServiceImpl : ArchivoMedicoService
    {
        private readonly ArchivoMedicoRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ArchivoMedicoServiceImpl"/>.
        /// </summary>
        /// <param name="repository">El repositorio para acceso a los Archivos Medicos.</param>
        /// <param name="mapper"> El mappeador para convertir los DTOs a Modelos.</param>
        public ArchivoMedicoServiceImpl(ArchivoMedicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Crea un archivo medico nuevo.
        /// </summary>
        /// <param name="createDTO">Los detalles del archivo medico a crear.</param>
        /// <returns>El archivo medico creado.</returns>
        public async Task<TArchivoMedico> AddArchivoMedico(ArchivoMedicoCreateDTO createDTO)
        {
            TArchivoMedico auxCreate = _mapper.Map<TArchivoMedico>(createDTO);
            auxCreate.FechaInicio = DateOnly.FromDateTime(createDTO.FechaInicio.Value);
            auxCreate.FecIng = DateOnly.FromDateTime(DateTime.Now);
            TArchivoMedico auxReturn = await _repository.CreateArchivoMedico(auxCreate);
            return auxReturn;
        }

        /// <summary>
        /// Borrado Logico de un archivo medico.
        /// </summary>
        /// <param name="deleteDTO">Los detalles del archivo medico a borrar.</param>
        /// <returns>Un booleano indicando si el borrado fue exitoso o no.</returns>
        public async Task<bool> DeleteArchivoMedico(ArchivoMedicoDeleteDTO deleteDTO)
        {
            TArchivoMedico auxDelete = _mapper.Map<TArchivoMedico>(deleteDTO);
            auxDelete.FecBaja = DateOnly.FromDateTime(DateTime.Now);
            bool auxResult = await _repository.DeleteArchivoMedico(auxDelete);
            return auxResult;
        }

        /// <summary>
        /// Obtiene un archivo medico especifico por su Identificador.
        /// </summary>
        /// <param name="id">El identificador del Archivo medico a Obtener.</param>
        /// <returns>El archivo medico si se encuentra o nulo sino.</returns>
        public async Task<TArchivoMedico> GetArchivMedicoById(int id)
        {
            TArchivoMedico archivoMedico = await _repository.GetArchivoMedico(id);
            return archivoMedico;
        }

        /// <summary>
        /// Obtiene una lista de Archivos Medicos filtrada y paginada basado en los criterios especificos.
        /// </summary>
        /// <param name="filterDTO">Objeto con los criterios de filtrado para los Archivos Medicos.</param>
        /// <returns> Una respuesta paginada conteniendo los archivos medicos filtrados.</returns>
        public async Task<PageResponse> GetFilterArchivosMedicos(FilterDTO filterDTO)
        {
            IQueryable<TArchivoMedico> query = _repository.GetArchivoMedicos();

            if (filterDTO.FechaInicio.HasValue)
            {
                query = query.Where(x => x.FechaInicio >= filterDTO.FechaInicio.Value);
            }

            if (filterDTO.FechaFin.HasValue)
            {
                query = query.Where(x => x.FechaFin <= filterDTO.FechaFin.Value);
            }

            if (filterDTO.IdEstado.HasValue)
            {
                query = query.Where(x => x.IdEstado == filterDTO.IdEstado.Value);
            }

            if (filterDTO.IdTipoArchivoMedico.HasValue)
            {
                query = query.Where(x => x.IdTipoArchivoMedico == filterDTO.IdTipoArchivoMedico.Value);
            }

            int totalCount = await query.CountAsync();

            var pagedResult = await query
                .Skip((filterDTO.Page - 1) * filterDTO.PageSize)
                .Take(filterDTO.PageSize)
                .ToListAsync();

            return new PageResponse
            {
                Page = filterDTO.Page,
                PageSize = filterDTO.PageSize,
                Archivos = pagedResult,
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Actualiza un archivo medico existente.
        /// </summary>
        /// <param name="updateDTO">Los detalles del archivo medico a actualizar.</param>
        /// <returns>El archivo medico actualizado.</returns>
        public async Task<TArchivoMedico> UpdateArchivoMedico(ArchivoMedicoUpdateDTO updateDTO)
        {
            TArchivoMedico auxUpdate = _mapper.Map<TArchivoMedico>(updateDTO);
            TArchivoMedico auxReturn = await _repository.UpdateArchivoMedico(auxUpdate);
            return auxReturn;
        }
    }
}
