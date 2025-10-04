using Entity.Dtos.Base;

namespace Entity.Dtos.UserDTO
{
    /// <summary>
    /// DTO para representar la información de un usuario del gimnasio.
    /// Utilizado en operaciones de creación, lectura y transferencia de datos de usuarios.
    /// </summary>
    public class UserDto : BaseDto
    {
        /// <summary>
        /// Nombre(s) del usuario
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Apellido(s) del usuario
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Número de identificación o documento del usuario
        /// </summary>
        public string Identification { get; set; }

        /// <summary>
        /// Número de teléfono de contacto del usuario
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Correo electrónico del usuario
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Fecha en que el usuario se registró en el sistema
        /// </summary>
        public DateTime RegistrationDate { get; set; }

    }
}
