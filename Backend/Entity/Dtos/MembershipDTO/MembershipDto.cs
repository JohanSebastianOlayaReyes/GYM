using Entity.Dtos.Base;

namespace Gym;

public class MembershipDto : BaseDto
{
    public int UserId { get; set; }
    public string Type { get; set; } // monthly, biweekly, daily, trial, etc.
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ServiceId { get; set; }
}
