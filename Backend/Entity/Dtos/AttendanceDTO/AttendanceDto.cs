using Entity.Dtos.Base;

namespace Gym;

public class AttendanceDto : BaseDto
{
        public int UserId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string RegistrationMethod { get; set; } // ID, fingerprint, etc.
    
}
