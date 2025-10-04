using Entity.Model.Base;
using Gym;

namespace Entity.Model
{
    public class User : BaseEntity
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Identification { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    public int? CurrentMembershipId { get; set; }

    public virtual ICollection<UserRole> Roles { get; set; }
    public virtual ICollection<Membership> Memberships { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<Attendance> Attendances { get; set; }
    public virtual ICollection<Notification> Notifications { get; set; }
    }
}
