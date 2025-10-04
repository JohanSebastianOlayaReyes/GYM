using Entity.Dtos.Base;

namespace Gym;

public class RolePermissionUpdate : BaseDto
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
}
