using Entity.Dtos.Base;

namespace Entity.Dtos.PermissionDto
{
    public class UpdatePermissionDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        }
}
