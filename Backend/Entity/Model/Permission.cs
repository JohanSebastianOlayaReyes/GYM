using Entity.Model.Base;

namespace Entity.Model
{
    public class Permission : BaseEntity
    {
    public string Name { get; set; } // MANAGE_USERS, MANAGE_SERVICES, VIEW_REPORTS, etc.
    public string Description { get; set; }

    public virtual ICollection<RolePermission> Roles { get; set; }
}
}
