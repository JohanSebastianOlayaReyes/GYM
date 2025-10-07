using Business.Interfaces;
using Gym;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de servicios del gimnasio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceBusiness _serviceBusiness;

        public ServiceController(IServiceBusiness serviceBusiness)
        {
            _serviceBusiness = serviceBusiness;
        }

        /// <summary>
        /// Obtiene todos los servicios del gimnasio.
        /// </summary>
        /// <returns>Lista de servicios.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var services = await _serviceBusiness.GetAllAsync();
                return Ok(new { success = true, data = services });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un servicio por su ID.
        /// </summary>
        /// <param name="id">ID del servicio.</param>
        /// <returns>Datos del servicio.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var service = await _serviceBusiness.GetByIdAsync(id);
                if (service == null)
                    return NotFound(new { success = false, message = "Servicio no encontrado" });

                return Ok(new { success = true, data = service });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene todos los servicios activos.
        /// </summary>
        /// <returns>Lista de servicios activos.</returns>
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                var services = await _serviceBusiness.GetActiveServicesAsync();
                return Ok(new { success = true, data = services });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene servicios de tipo suscripción.
        /// </summary>
        /// <returns>Lista de servicios de suscripción.</returns>
        [HttpGet("subscriptions")]
        public async Task<IActionResult> GetSubscriptions()
        {
            try
            {
                var services = await _serviceBusiness.GetSubscriptionServicesAsync();
                return Ok(new { success = true, data = services });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo servicio.
        /// </summary>
        /// <param name="serviceDto">Datos del servicio a crear.</param>
        /// <returns>Servicio creado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceDTO serviceDto)
        {
            try
            {
                var createdService = await _serviceBusiness.CreateAsync(serviceDto);
                return CreatedAtAction(nameof(GetById), new { id = createdService.Id },
                    new { success = true, data = createdService, message = "Servicio creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un servicio existente.
        /// </summary>
        /// <param name="id">ID del servicio a actualizar.</param>
        /// <param name="serviceDto">Datos actualizados del servicio.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceDTO serviceDto)
        {
            try
            {
                serviceDto.Id = id;
                var result = await _serviceBusiness.UpdateAsync(serviceDto);

                if (result)
                    return Ok(new { success = true, message = "Servicio actualizado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo actualizar el servicio" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina lógicamente un servicio.
        /// </summary>
        /// <param name="id">ID del servicio a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteDto = new DeleteLogicalServiceDto { Id = id, Status = false };
                var result = await _serviceBusiness.DeleteAsync(deleteDto);

                if (result)
                    return Ok(new { success = true, message = "Servicio eliminado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar el servicio" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
