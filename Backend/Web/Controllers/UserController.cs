using Business.Interfaces;
using Entity.Dtos.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de usuarios del gimnasio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        /// <summary>
        /// Obtiene todos los usuarios del gimnasio.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userBusiness.GetAllAsync();
                return Ok(new { success = true, data = users });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Datos del usuario.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userBusiness.GetByIdAsync(id);
                if (user == null)
                    return NotFound(new { success = false, message = "Usuario no encontrado" });

                return Ok(new { success = true, data = user });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="userDto">Datos del usuario a crear.</param>
        /// <returns>Usuario creado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            try
            {
                var createdUser = await _userBusiness.CreateAsync(userDto);
                return CreatedAtAction(nameof(GetById), new { id = createdUser.Id },
                    new { success = true, data = createdUser, message = "Usuario creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="id">ID del usuario a actualizar.</param>
        /// <param name="updateDto">Datos actualizados del usuario.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto updateDto)
        {
            try
            {
                updateDto.Id = id;
                var result = await _userBusiness.UpdateParcialUserAsync(updateDto);

                if (result)
                    return Ok(new { success = true, message = "Usuario actualizado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo actualizar el usuario" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina lógicamente un usuario.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteDto = new DeleteLogicalUserDto { Id = id, Status = false };
                var result = await _userBusiness.SetUserActiveAsync(deleteDto);

                if (result)
                    return Ok(new { success = true, message = "Usuario eliminado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar el usuario" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un usuario por su email.
        /// </summary>
        /// <param name="email">Email del usuario.</param>
        /// <returns>Datos del usuario.</returns>
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var user = await _userBusiness.GetByEmailAsync(email);
                if (user == null)
                    return NotFound(new { success = false, message = "Usuario no encontrado" });

                return Ok(new { success = true, data = user });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
