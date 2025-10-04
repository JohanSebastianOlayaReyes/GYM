using Entity.Dtos.Base;

namespace Gym;

public class RolePermissionDto : BaseDto
{
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
}
