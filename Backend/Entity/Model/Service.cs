using Entity.Model.Base;

namespace Gym;

public class Service : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsSubscription { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Membership> Memberships { get; set; }
    
}
