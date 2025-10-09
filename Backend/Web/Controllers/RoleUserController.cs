using Business.Interfaces;
using Entity.Dtos.RolUserDTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de relaciones entre usuarios y roles.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RoleUserController : ControllerBase
    {
        private readonly IRoleUserBusiness _roleUserBusiness;

        public RoleUserController(IRoleUserBusiness roleUserBusiness)
        {
            _roleUserBusiness = roleUserBusiness;
        }

        /// <summary>
        /// Obtiene todas las relaciones usuario-rol del sistema.
        /// </summary>
        /// <returns>Lista de relaciones usuario-rol.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roleUsers = await _roleUserBusiness.GetAllAsync();
                return Ok(new { success = true, data = roleUsers });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene una relación usuario-rol por su ID.
        /// </summary>
        /// <param name="id">ID de la relación usuario-rol.</param>
        /// <returns>Datos de la relación.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var roleUser = await _roleUserBusiness.GetByIdAsync(id);
                if (roleUser == null)
                    return NotFound(new { success = false, message = "Relación usuario-rol no encontrada" });

                return Ok(new { success = true, data = roleUser });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nueva relación usuario-rol.
        /// </summary>
        /// <param name="roleUserDto">Datos de la relación a crear.</param>
        /// <returns>Relación creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRoleDto roleUserDto)
        {
            try
            {
                var createdRoleUser = await _roleUserBusiness.CreateAsync(roleUserDto);
                return CreatedAtAction(nameof(GetById), new { id = createdRoleUser.Id },
                    new { success = true, data = createdRoleUser, message = "Relación usuario-rol creada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza una relación usuario-rol existente.
        /// </summary>
        /// <param name="id">ID de la relación a actualizar.</param>
        /// <param name="updateDto">Datos actualizados de la relación.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRoleDto updateDto)
        {
            try
            {
                updateDto.Id = id;
                var result = await _roleUserBusiness.UpdateParcialRoleUserAsync(updateDto);

                if (result)
                    return Ok(new { success = true, message = "Relación usuario-rol actualizada exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo actualizar la relación usuario-rol" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una relación usuario-rol.
        /// </summary>
        /// <param name="id">ID de la relación a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _roleUserBusiness.DeleteAsync(id);

                if (result)
                    return Ok(new { success = true, message = "Relación usuario-rol eliminada exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar la relación usuario-rol" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
