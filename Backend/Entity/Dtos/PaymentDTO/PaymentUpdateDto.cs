using Entity.Dtos.Base;

namespace Gym;

public class PaymentUpdateDto : BaseDto
{
    public int UserId { get; set; }
    public int MembershipId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Method { get; set; } // 'cash'
    public string Reference { get; set; }
}
