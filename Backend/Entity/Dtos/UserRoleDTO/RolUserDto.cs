using Entity.Dtos.Base;

namespace Entity.Dtos.RolUserDTO
{
    /// <summary>
    /// DTO para mostrar información básica de una asignación de rol a usuario (operación GET ALL, CREATE, UPDATE(PATCH-PUT))
    /// </summary>
    public class UserRoleDto : BaseDto
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
