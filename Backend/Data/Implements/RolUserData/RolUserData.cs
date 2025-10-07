using Data.Implements.BaseData;
using Data.Interfaces; // Añade esta línea
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.RolUserData;

public class RolUserData : BaseModelData<UserRole>, IRolUserData
{
    public RolUserData(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> UpdatePartial(UserRole rolUser)
    {
        var existingRolUser = await _context.UserRoles.FindAsync(rolUser.Id);
        if (existingRolUser == null) return false;
        // Update only the fields that are not null
        if (rolUser.RoleId > 0) existingRolUser.RoleId = rolUser.RoleId;
        if (rolUser.UserId > 0) existingRolUser.UserId = rolUser.UserId;
        _context.UserRoles.Update(existingRolUser);
        await _context.SaveChangesAsync();
        return true;
    }
}