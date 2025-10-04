using Entity.Dtos.Base;

namespace Entity.Dtos.RolUserDTO
{
    /// <summary>
    /// DTO utilizado para actualizar la asignación de un rol a un usuario existente
    /// </summary>
    public class UpdateUserRoleDto : BaseDto
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
