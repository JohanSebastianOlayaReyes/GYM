using System.ComponentModel.DataAnnotations;

namespace Entity.Dtos.AdminDTO
{
    /// <summary>
    /// DTO para el registro de un nuevo administrador.
    /// </summary>
    public class AdminRegisterDto
    {
        /// <summary>
        /// Nombre del administrador.
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        /// <summary>
        /// Correo electrónico del administrador.
        /// </summary>
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Email { get; set; }

        /// <summary>
        /// Nombre del gimnasio.
        /// </summary>
        [Required(ErrorMessage = "El nombre del gimnasio es requerido")]
        public string GymName { get; set; }

        /// <summary>
        /// Contraseña del administrador.
        /// </summary>
        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; }
    }
}
