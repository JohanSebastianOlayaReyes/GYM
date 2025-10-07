
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
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string password)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;
            // Note: Password property doesn't exist in User entity
            // You may need to add it or handle authentication differently
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
            // Note: Password property doesn't exist in User entity
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

            // Crear una nueva relación UserRole incluyendo los miembros requeridos
            var rolUser = new UserRole
            {
                UserId = userId,
                RoleId = rolId,
                Status = true,
                CreatedAt = DateTime.UtcNow,
                User = user,
                Role = rol
            };

            await _context.UserRoles.AddAsync(rolUser);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
