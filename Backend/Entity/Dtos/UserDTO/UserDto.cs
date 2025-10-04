using Entity.Dtos.Base;

namespace Entity.Dtos.UserDTO
{
    /// <summary>
    /// DTO para mostrar información básica de un usuario (operación get all, create, update(patch-put))
    /// </summary>
    public class UserDto : BaseDto
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Identification { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }

    }
}
