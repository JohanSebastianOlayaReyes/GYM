using Entity.Dtos.Base;

namespace Entity.Dtos.RolUserDTO
{
    /// <summary>
    /// DTO para representar la asignación de un rol a un usuario.
    /// Utilizado en operaciones de creación, lectura y transferencia de datos de relaciones usuario-rol.
    /// </summary>
    public class UserRoleDto : BaseDto
    {
        /// <summary>
        /// Identificador del rol asignado
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Identificador del usuario al que se asigna el rol
        /// </summary>
        public int UserId { get; set; }
    }
}
