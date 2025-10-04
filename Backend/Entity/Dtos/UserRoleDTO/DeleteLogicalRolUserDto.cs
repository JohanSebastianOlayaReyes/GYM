using Entity.Dtos.Base;

namespace Entity.Dtos.UserRoleDTO
{
    /// <summary>
    /// DTO para la creación de una nueva asignación de rol a usuario (operación DELETE Logical)
    /// </summary>
    public class DeleteLogicalUserRoleDto : BaseDto
    {
        public DeleteLogicalUserRoleDto()
        {
            Status = false;
        }
    }
}
