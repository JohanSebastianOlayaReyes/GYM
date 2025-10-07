using Entity.Model.Base;

namespace Entity.Model
{
    /// <summary>
    /// Representa un administrador del sistema del gimnasio.
    /// Gestiona la información de autenticación y datos del gimnasio.
    /// </summary>
    public class Admin : BaseEntity
    {
        /// <summary>
        /// Obtiene o establece el nombre del administrador.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del administrador.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña hasheada del administrador.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del gimnasio.
        /// </summary>
        public string GymName { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación de la cuenta del administrador.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la última actualización de la cuenta.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
