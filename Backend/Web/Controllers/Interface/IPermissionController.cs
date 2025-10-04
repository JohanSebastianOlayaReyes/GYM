using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.PermissionDto;
using Entity.Model;
using Entity.Dtos.Permission;

namespace Web.Controllers.Interface
{
    public interface IPermissionController : IGenericController<PermissionDto, Permission>
    {
        Task<IActionResult> UpdatePartialPermission(int id, int permissionId, UpdatePermissionDto dto);
        Task<IActionResult> DeleteLogicPermission(int id);
    }
}
