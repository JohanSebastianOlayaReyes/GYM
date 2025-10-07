using Entity.Dtos.Base;

namespace Entity.Dtos.UserDTO
{
    /// <summary>
    /// DTO utilizado para asignar un rol a un usuario
    /// </summary>
    public class AssignUserRolDto
    {
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Identificador del rol a asignar
        /// </summary>
        public int RoleId { get; set; }
    }
}
