using Business.Interfaces;
using Entity.Dtos.Permission;
using Entity.Dtos.PermissionDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de permisos del sistema.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionBusiness _permissionBusiness;

        public PermissionController(IPermissionBusiness permissionBusiness)
        {
            _permissionBusiness = permissionBusiness;
        }

        /// <summary>
        /// Obtiene todos los permisos del sistema.
        /// </summary>
        /// <returns>Lista de permisos.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var permissions = await _permissionBusiness.GetAllAsync();
                return Ok(new { success = true, data = permissions });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un permiso por su ID.
        /// </summary>
        /// <param name="id">ID del permiso.</param>
        /// <returns>Datos del permiso.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var permission = await _permissionBusiness.GetByIdAsync(id);
                if (permission == null)
                    return NotFound(new { success = false, message = "Permiso no encontrado" });

                return Ok(new { success = true, data = permission });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo permiso.
        /// </summary>
        /// <param name="permissionDto">Datos del permiso a crear.</param>
        /// <returns>Permiso creado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PermissionDto permissionDto)
        {
            try
            {
                var createdPermission = await _permissionBusiness.CreateAsync(permissionDto);
                return CreatedAtAction(nameof(GetById), new { id = createdPermission.Id },
                    new { success = true, data = createdPermission, message = "Permiso creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un permiso existente.
        /// </summary>
        /// <param name="id">ID del permiso a actualizar.</param>
        /// <param name="updateDto">Datos actualizados del permiso.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePermissionDto updateDto)
        {
            try
            {
                updateDto.Id = id;
                var result = await _permissionBusiness.UpdatePartialPermissionAsync(updateDto);

                if (result)
                    return Ok(new { success = true, message = "Permiso actualizado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo actualizar el permiso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina lógicamente un permiso.
        /// </summary>
        /// <param name="id">ID del permiso a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteDto = new DeleteLogicalPermissionDto { Id = id, Status = false };
                var result = await _permissionBusiness.DeleteLogicPermissionAsync(deleteDto);

                if (result)
                    return Ok(new { success = true, message = "Permiso eliminado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar el permiso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
