using Business.Interfaces;
using Entity.Dtos.AdminDTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la autenticación de administradores.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBusiness _adminBusiness;

        public AdminController(IAdminBusiness adminBusiness)
        {
            _adminBusiness = adminBusiness;
        }

        /// <summary>
        /// Registra un nuevo administrador en el sistema.
        /// </summary>
        /// <param name="registerDto">Datos del administrador a registrar.</param>
        /// <returns>Información del administrador registrado con su token de acceso.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AdminRegisterDto registerDto)
        {
            try
            {
                var result = await _adminBusiness.RegisterAsync(registerDto);
                return Ok(new { success = true, data = result, message = "Administrador registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Autentica a un administrador existente.
        /// </summary>
        /// <param name="loginDto">Credenciales de inicio de sesión.</param>
        /// <returns>Información del administrador autenticado con su token de acceso.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginDto loginDto)
        {
            try
            {
                var result = await _adminBusiness.LoginAsync(loginDto);
                return Ok(new { success = true, data = result, message = "Inicio de sesión exitoso" });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Verifica si un correo electrónico ya está registrado.
        /// </summary>
        /// <param name="email">Correo electrónico a verificar.</param>
        /// <returns>True si el email existe, False si no.</returns>
        [HttpGet("check-email/{email}")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            try
            {
                var exists = await _adminBusiness.ExistsByEmailAsync(email);
                return Ok(new { success = true, exists = exists });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
