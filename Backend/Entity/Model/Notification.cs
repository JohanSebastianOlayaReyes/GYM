using Entity.Model;
using Entity.Model.Base;

namespace Gym;

public class Notification : BaseEntity
{
    public int UserId { get; set; }
    public string Type { get; set; } // expiration, promotion, reminder, etc.
    public string Message { get; set; }
    public DateTime SentDate { get; set; }


    public virtual User User { get; set; }
}
