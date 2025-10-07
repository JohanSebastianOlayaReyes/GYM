using Entity.Dtos.Base;

namespace Entity.Dtos.UserDTO
{
    /// <summary>
    /// DTO utilizado para actualizar la contraseña de un usuario
    /// </summary>
    public class UpdatePasswordUserDto : BaseDto
    {
        /// <summary>
        /// Nueva contraseña del usuario
        /// </summary>
        public string NewPassword { get; set; }
    }
}
