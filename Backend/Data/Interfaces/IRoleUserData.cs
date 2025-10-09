using Data.Implements.RolUserData;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRolUserData : IBaseModelData<UserRole>
    {
        Task<bool> UpdatePartial(UserRole rolUser);
    }
}
