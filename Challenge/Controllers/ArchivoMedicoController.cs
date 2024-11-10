using Challenge.DTO;
using Challenge.Models;
using Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    /// <summary>
    /// Controlador para el manejo de Archivos Medicos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivoMedicoController : Controller
    {
        private readonly ArchivoMedicoService _service;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ArchivoMedicoController"/>.
        /// </summary>
        /// <param name="service">El servicio para el manejo de Archivos Medicos.</param>
        public ArchivoMedicoController(ArchivoMedicoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene los archivos medicos filtrados y paginados segun los criterios ingresados.
        /// </summary>
        /// <param name="filterDTO">El objeto con los criterios de filtrado.</param>
        /// <returns>Un objeto <see cref="ActionResult"/> conteniendo un <see cref="BaseResponse"/> con un objeto <see cref="PageResponse"/> sobre archivos medicos.</returns>
        [HttpGet("/archivos")]
        public async Task<ActionResult<BaseResponse<PageResponse>>> GetFilterArchivosMedicos([FromQuery] FilterDTO filterDTO)
        {
            try
            {
                PageResponse page = await _service.GetFilterArchivosMedicos(filterDTO);
                if (page.Archivos == null || page.Archivos.Count == 0)
                {
                    return NotFound(new BaseResponse<PageResponse>
                    {
                        TotalRows = 0,
                        Code = 404,
                        Data = null,
                        Exception = null,
                        Message = "No se encontraron archivos para la busqueda",
                        Success = false
                    });
                }
                return Ok(new BaseResponse<PageResponse>
                {
                    TotalRows = page.TotalCount,
                    Code = 200,
                    Data = page,
                    Exception = null,
                    Message = "Exito al buscar",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponse<TArchivoMedico>
                {
                    TotalRows = 0,
                    Code = 500,
                    Data = null,
                    Exception = ex.Message,
                    Success = false,
                    Message = ex.Message.ToString()
                });
            }
        }

        /// <summary>
        /// Obtiene un Archivo Medico especifico por el Identificador unico.
        /// </summary>
        /// <param name="id">El identificador del Archivo Medico a obtener.</param>
        /// <returns>Un <see cref="ActionResult"/> conteniendo un <see cref="BaseResponse"/> con el Archivo Medico.</returns>
        [HttpGet("/archivo")]
        public async Task<ActionResult<BaseResponse<TArchivoMedico>>> GetArchivoMedicoById(int id)
        {
            try
            {
                TArchivoMedico archivoMedico = await _service.GetArchivMedicoById(id);
                if (archivoMedico == null)
                {
                    return NotFound(new BaseResponse<TArchivoMedico>
                    {
                        TotalRows = 0,
                        Code = 404,
                        Data = null,
                        Exception = null,
                        Message = "No se encontró el archivo para la busqueda",
                        Success = false
                    });
                }
                return Ok(new BaseResponse<TArchivoMedico>
                {
                    TotalRows = 1,
                    Code = 200,
                    Data = archivoMedico,
                    Exception = null,
                    Message = "Exito al buscar",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponse<TArchivoMedico>
                {
                    TotalRows = 0,
                    Code = 500,
                    Data = null,
                    Exception = ex.Message,
                    Success = false,
                    Message = ex.Message.ToString()
                });
            }
        }

        /// <summary>
        /// Crea un nuevo Archivo Medico.
        /// </summary>
        /// <param name="createDTO">Los detalles del archivo Medico a crear.</param>
        /// <returns>Un <see cref="ActionResult"/> conteniendo un <see cref="BaseResponse"/> con el archivo medico creado.</returns>
        [HttpPost("/archivo")]
        public async Task<ActionResult<BaseResponse<TArchivoMedico>>> CreateArchivoMedico([FromBody] ArchivoMedicoCreateDTO createDTO)
        {
            try
            {
                var result = await _service.AddArchivoMedico(createDTO);
                return Ok(new BaseResponse<TArchivoMedico>
                {
                    TotalRows = 1,
                    Code = 200,
                    Data = result,
                    Exception = null,
                    Success = true,
                    Message = "Archivo Creado con exito"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponse<TArchivoMedico>
                {
                    TotalRows = 0,
                    Code = 500,
                    Data = null,
                    Exception = ex.Message,
                    Success = false,
                    Message = ex.Message.ToString()
                });
            }
        }

        /// <summary>
        /// Actualiza un archivo medico existente.
        /// </summary>
        /// <param name="updateDTO">Los detalles actualizados del Archivo Medico.</param>
        /// <returns>Un <see cref="ActionResult"/> conteniendo una <see cref="BaseResponse"/> con el archivo medico actualizado.</returns>
        [HttpPut("/archivo")]
        public async Task<ActionResult<BaseResponse<TArchivoMedico>>> UpdateArchivoMedico([FromBody] ArchivoMedicoUpdateDTO updateDTO)
        {
            try
            {
                TArchivoMedico result = await _service.UpdateArchivoMedico(updateDTO);
                if (result == null)
                {
                    return NotFound(new BaseResponse<TArchivoMedico>
                    {
                        TotalRows = 0,
                        Code = 404,
                        Data = null,
                        Exception = null,
                        Message = "No se encontró el archivo para modificar",
                        Success = false
                    });
                }
                return Ok(new BaseResponse<TArchivoMedico>
                {
                    TotalRows = 1,
                    Code = 200,
                    Data = result,
                    Exception = null,
                    Success = true,
                    Message = "Archivo Actualizado con exito"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponse<TArchivoMedico>
                {
                    TotalRows = 0,
                    Code = 500,
                    Data = null,
                    Exception = ex.Message,
                    Success = false,
                    Message = ex.Message.ToString()
                });
            }
        }

        /// <summary>
        /// Borrado Logico de un Archivo Medico.
        /// </summary>
        /// <param name="deleteDTO">Los detalles del archivo medico a borrar.</param>
        /// <returns>Un <see cref="ActionResult"/> conteniendo <see cref="BaseResponse"/> que indica el resultado del borrado.</returns>
        [HttpDelete("/archivo")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteArchivoMedico([FromBody] ArchivoMedicoDeleteDTO deleteDTO)
        {
            try
            {
                bool result = await _service.DeleteArchivoMedico(deleteDTO);
                if (result)
                {
                    return Ok(new BaseResponse<bool>
                    {
                        TotalRows = 1,
                        Code = 200,
                        Data = result,
                        Exception = null,
                        Success = true,
                        Message = "Archivo Borrado con exito"
                    });
                }
                else
                {
                    return NotFound(new BaseResponse<bool>
                    {
                        TotalRows = 0,
                        Code = 404,
                        Data = false,
                        Exception = null,
                        Message = "No se encontró el archivo para el borrado",
                        Success = false
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponse<bool>
                {
                    TotalRows = 0,
                    Code = 500,
                    Data = false,
                    Exception = ex.Message,
                    Success = false,
                    Message = ex.Message.ToString()
                });
            }
        }
    }
}
