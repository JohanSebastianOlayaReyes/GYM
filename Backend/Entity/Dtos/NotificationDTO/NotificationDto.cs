using Entity.Dtos.Base;

namespace Gym;

public class NotificationDto : BaseDto
{
    public int UserId { get; set; }
    public string Type { get; set; } // expiration, promotion, reminder, etc.
    public string Message { get; set; }
    public DateTime SentDate { get; set; }
}