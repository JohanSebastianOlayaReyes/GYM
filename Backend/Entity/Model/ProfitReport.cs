using Entity.Model.Base;

namespace Gym;

public class ProfitReport : BaseEntity
{
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal TotalIncome { get; set; }
    public virtual ICollection<Payment> PaymentDetails { get; set; }
    
}
