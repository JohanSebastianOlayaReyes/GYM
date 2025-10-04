using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Data.Interfaces
{
    public interface IUserData : IBaseModelData<User>
    {
        Task<User> LoginAsync(string email, string password);
        Task<bool> ChangePasswordAsync(int userId,string password);
        Task<User> GetByEmailAsync(string email);
        Task<bool> Active(int id,bool status);
        Task<bool> UpdatePartial(User user);
        Task<bool> AssingRolAsync(int userId, int rolId);
         
    }
}
