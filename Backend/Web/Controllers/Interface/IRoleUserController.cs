
using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolUserDTO;
using Entity.Model;
using Web.Controllers.Interface;

namespace Web.Controllers.Interface
{
    public interface IRoleUserController : IGenericController<UserRoleDto, UserRole>
    {
    Task<IActionResult> UpdatePartialRoleUser(int id, int roluser, UpdateUserRoleDto dto);
    }
}