using Business.Interfaces;
using Entity.Dtos.MembershipDTO;
using Gym;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de membresías del gimnasio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipBusiness _membershipBusiness;

        public MembershipController(IMembershipBusiness membershipBusiness)
        {
            _membershipBusiness = membershipBusiness;
        }

        /// <summary>
        /// Obtiene todas las membresías.
        /// </summary>
        /// <returns>Lista de membresías.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var memberships = await _membershipBusiness.GetAllAsync();
                return Ok(new { success = true, data = memberships });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene una membresía por su ID.
        /// </summary>
        /// <param name="id">ID de la membresía.</param>
        /// <returns>Datos de la membresía.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var membership = await _membershipBusiness.GetByIdAsync(id);
                if (membership == null)
                    return NotFound(new { success = false, message = "Membresía no encontrada" });

                return Ok(new { success = true, data = membership });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene todas las membresías activas.
        /// </summary>
        /// <returns>Lista de membresías activas.</returns>
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                var memberships = await _membershipBusiness.GetActiveMembershipsAsync();
                return Ok(new { success = true, data = memberships });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene todas las membresías expiradas.
        /// </summary>
        /// <returns>Lista de membresías expiradas.</returns>
        [HttpGet("expired")]
        public async Task<IActionResult> GetExpired()
        {
            try
            {
                var memberships = await _membershipBusiness.GetExpiredMembershipsAsync();
                return Ok(new { success = true, data = memberships });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene membresías por usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Lista de membresías del usuario.</returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var memberships = await _membershipBusiness.GetByUserIdAsync(userId);
                return Ok(new { success = true, data = memberships });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene la membresía actual de un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Membresía actual del usuario.</returns>
        [HttpGet("user/{userId}/current")]
        public async Task<IActionResult> GetCurrentByUserId(int userId)
        {
            try
            {
                var membership = await _membershipBusiness.GetCurrentMembershipByUserIdAsync(userId);
                if (membership == null)
                    return NotFound(new { success = false, message = "El usuario no tiene membresía activa" });

                return Ok(new { success = true, data = membership });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el conteo de membresías activas.
        /// </summary>
        /// <returns>Número de membresías activas.</returns>
        [HttpGet("active/count")]
        public async Task<IActionResult> GetActiveCount()
        {
            try
            {
                var count = await _membershipBusiness.GetActiveMembershipsCountAsync();
                return Ok(new { success = true, data = count });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nueva membresía.
        /// </summary>
        /// <param name="membershipDto">Datos de la membresía a crear.</param>
        /// <returns>Membresía creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MembershipDto membershipDto)
        {
            try
            {
                var createdMembership = await _membershipBusiness.CreateAsync(membershipDto);
                return CreatedAtAction(nameof(GetById), new { id = createdMembership.Id },
                    new { success = true, data = createdMembership, message = "Membresía creada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza una membresía existente.
        /// </summary>
        /// <param name="id">ID de la membresía a actualizar.</param>
        /// <param name="updateDto">Datos actualizados de la membresía.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MembershipUpdateDto updateDto)
        {
            try
            {
                var membershipDto = new MembershipDto
                {
                    Id = id,
                    UserId = updateDto.UserId,
                    Type = updateDto.Type,
                    StartDate = updateDto.StartDate,
                    EndDate = updateDto.EndDate,
                    ServiceId = updateDto.ServiceId,
                    Status = updateDto.Status
                };
                var result = await _membershipBusiness.UpdateAsync(membershipDto);

                if (result != null)
                    return Ok(new { success = true, message = "Membresía actualizada exitosamente", data = result });

                return BadRequest(new { success = false, message = "No se pudo actualizar la membresía" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Extiende la duración de una membresía.
        /// </summary>
        /// <param name="id">ID de la membresía.</param>
        /// <param name="additionalDays">Días adicionales a agregar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPatch("{id}/extend")]
        public async Task<IActionResult> Extend(int id, [FromBody] int additionalDays)
        {
            try
            {
                var result = await _membershipBusiness.ExtendMembershipAsync(id, additionalDays);

                if (result)
                    return Ok(new { success = true, message = $"Membresía extendida por {additionalDays} días" });

                return BadRequest(new { success = false, message = "No se pudo extender la membresía" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina lógicamente una membresía.
        /// </summary>
        /// <param name="id">ID de la membresía a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _membershipBusiness.DeleteAsync(id);

                if (result)
                    return Ok(new { success = true, message = "Membresía eliminada exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar la membresía" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
