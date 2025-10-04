using Entity.Dtos.Base;

namespace Entity.Dtos.RolDTO
{
    /// <summary>
    /// DTO para la creación de un nuevo rol (operación Delete Logico)
    /// </summary>
    public class DeleteLogicalRoleDto : BaseDto
    {
        public DeleteLogicalRoleDto()
        {
            Status = false;
        }
    }
}
