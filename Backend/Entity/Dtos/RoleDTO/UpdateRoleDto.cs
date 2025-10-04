using Entity.Dtos.Base;

namespace Entity.Dtos.RolDTO
{
    /// <summary>
    /// DTO para mostrar información básica de un rol (operación GET ALL,CREATE,UPDATE(PATCH-PUT))
    /// </summary>
    public class UpdateRoleDto : BaseDto
    {
        public  string Name { get; set; }
        public  string Description { get; set; }
    }
}
