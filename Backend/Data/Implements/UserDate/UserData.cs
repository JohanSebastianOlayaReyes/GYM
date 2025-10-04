
using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;



namespace Data.Implements.UserDate
{   
    public class UserData : BaseModelData<User> , IUserData
    {

        public UserData(ApplicationDbContext context) : base(context)
            
        {
            
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string password)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;
            user.Password = password;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            // Reemplaza el llamado del metodo GETBYID con uno ya establecido con _dbSet
            var users = await _context.Users.ToListAsync(); // uso correcto del _dbSet
            return users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }


        public async Task<bool> Active(int id,bool status)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Status == status);
            if (user == null) return false;
            user.Status = !status;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePartial(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null) return false;
            // Actualiza solo los campos q no son nulos
            if (!string.IsNullOrEmpty(user.Email)) existingUser.Email = user.Email;
            if (!string.IsNullOrEmpty(user.Password)) existingUser.Password = user.Password;
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AssingRolAsync(int userId, int rolId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            var rol = await _context.Roles.FindAsync(rolId);
            if (rol == null) return false;

            // Crear una nueva relación RolUser incluyendo los miembros requeridos
            var rolUser = new RolUser
            {
                UserId = userId,
                RolId = rolId,
                Status = true,
                CreatedAt = DateTime.UtcNow,
                User = user,
                Rol = rol
            };

            await _context.RolUsers.AddAsync(rolUser);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
