using Entity.Model;
using Entity.Model.Base;

namespace Gym;

public class Attendance : BaseEntity
{
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string RegistrationMethod { get; set; } // ID, fingerprint, etc.

    public virtual User User { get; set; }
    
}
