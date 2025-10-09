using Entity.Dtos.Base;

namespace Entity.Dtos.UserDTO
{
    /// <summary>
    /// DTO para cambiar el estado (activo/inactivo) de un usuario.
    /// </summary>
    public class UserStatusDto : BaseDto
    {
        /// <summary>
        /// Estado del usuario: true para activo, false para inactivo.
        /// </summary>
        public bool Status { get; set; }
    }
}
