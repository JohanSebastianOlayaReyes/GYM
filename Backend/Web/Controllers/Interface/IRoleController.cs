using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolDTO;
using Entity.Model;

namespace Web.Controllers.Interface
{
    public interface IRoleController : IGenericController<RoleDto, Role>
    {
        Task<IActionResult> UpdatePartialRole(int id, int roleId, UpdateRoleDto dto);
        Task<IActionResult> DeleteLogicRole(int id);
    }
}