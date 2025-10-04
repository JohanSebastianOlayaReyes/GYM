using Entity.Model.Base;

namespace Entity.Model
{
    public class Role : BaseEntity
    {
    public string Name { get; set; } // Admin, Employee, Client, etc.
    public string Description { get; set; }

    public virtual ICollection<UserRole> Users { get; set; }
    public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
