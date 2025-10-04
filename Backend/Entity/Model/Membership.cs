using Entity.Model;
using Entity.Model.Base;

namespace Gym;

public class Membership : BaseEntity
{
    public int UserId { get; set; }
    public string Type { get; set; } // monthly, biweekly, daily, trial, etc.
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ServiceId { get; set; }

    public virtual User User { get; set; }
    public virtual Service Service { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}