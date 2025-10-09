using Business.Interfaces;
using Entity.Dtos.RolDTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de roles del sistema.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleBusiness _roleBusiness;

        public RoleController(IRoleBusiness roleBusiness)
        {
            _roleBusiness = roleBusiness;
        }

        /// <summary>
        /// Obtiene todos los roles del sistema.
        /// </summary>
        /// <returns>Lista de roles.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _roleBusiness.GetAllAsync();
                return Ok(new { success = true, data = roles });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un rol por su ID.
        /// </summary>
        /// <param name="id">ID del rol.</param>
        /// <returns>Datos del rol.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var role = await _roleBusiness.GetByIdAsync(id);
                if (role == null)
                    return NotFound(new { success = false, message = "Rol no encontrado" });

                return Ok(new { success = true, data = role });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo rol.
        /// </summary>
        /// <param name="roleDto">Datos del rol a crear.</param>
        /// <returns>Rol creado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDto roleDto)
        {
            try
            {
                var createdRole = await _roleBusiness.CreateAsync(roleDto);
                return CreatedAtAction(nameof(GetById), new { id = createdRole.Id },
                    new { success = true, data = createdRole, message = "Rol creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un rol existente.
        /// </summary>
        /// <param name="id">ID del rol a actualizar.</param>
        /// <param name="updateDto">Datos actualizados del rol.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto updateDto)
        {
            try
            {
                updateDto.Id = id;
                var result = await _roleBusiness.UpdatePartialRolAsync(updateDto);

                if (result)
                    return Ok(new { success = true, message = "Rol actualizado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo actualizar el rol" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina lógicamente un rol.
        /// </summary>
        /// <param name="id">ID del rol a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteDto = new DeleteLogicalRoleDto { Id = id, Status = false };
                var result = await _roleBusiness.DeleteLogicRolAsync(deleteDto);

                if (result)
                    return Ok(new { success = true, message = "Rol eliminado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar el rol" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
