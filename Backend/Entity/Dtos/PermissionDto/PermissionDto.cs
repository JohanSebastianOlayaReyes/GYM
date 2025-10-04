using Entity.Dtos.Base;

namespace Entity.Dtos.Permission
{
    public class PermissionDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
