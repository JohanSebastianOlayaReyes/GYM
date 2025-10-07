using System.ComponentModel.DataAnnotations;

namespace Entity.Dtos.AdminDTO
{
    /// <summary>
    /// DTO para el inicio de sesión de un administrador.
    /// </summary>
    public class AdminLoginDto
    {
        /// <summary>
        /// Correo electrónico del administrador.
        /// </summary>
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Email { get; set; }

        /// <summary>
        /// Contraseña del administrador.
        /// </summary>
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
    }
}
