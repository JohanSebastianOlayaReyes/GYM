using Entity.Dtos.UserDTO;
using Entity.Model;
using Entity.Dtos; // Add this if UserStatusDto is in Entity.Dtos namespace
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserController : IGenericController<UserDto, User>
    {
        Task<IActionResult> GetUserByEmail(string email);
        Task<IActionResult> UpdatePartialUser(UpdateUserDto dto);
        Task<IActionResult> SetUserActive(int id, UserStatusDto dto);
       
    }
}