using Entity.Model;
using Entity.Model.Base;

namespace Gym;

public class Payment : BaseEntity
{
    public int UserId { get; set; }
    public int MembershipId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Method { get; set; } // 'cash'
    public string Reference { get; set; } // Optional

    public virtual User User { get; set; }
    public virtual Membership Membership { get; set; }
}
