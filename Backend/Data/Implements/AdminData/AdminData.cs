using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements.AdminData
{
    /// <summary>
    /// Implementación de operaciones de datos para administradores.
    /// </summary>
    public class AdminData : BaseModelData<Admin>, IAdminData
    {
        public AdminData(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Autentica a un administrador verificando email y contraseña.
        /// </summary>
        public async Task<Admin> LoginAsync(string email, string password)
        {
            return await _context.Admins
                .FirstOrDefaultAsync(a => a.Email == email && a.PasswordHash == password && a.Status == true);
        }

        /// <summary>
        /// Obtiene un administrador por su correo electrónico.
        /// </summary>
        public async Task<Admin> GetByEmailAsync(string email)
        {
            return await _context.Admins
                .FirstOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
        }

        /// <summary>
        /// Verifica si existe un administrador con el email proporcionado.
        /// </summary>
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Admins
                .AnyAsync(a => a.Email.ToLower() == email.ToLower());
        }

        /// <summary>
        /// Guarda un administrador en la base de datos de forma asíncrona.
        /// </summary>
        public async Task SaveAsync(Admin admin)
        {
            if (admin.Id == 0)
            {
                _context.Admins.Add(admin);
            }
            else
            {
                _context.Admins.Update(admin);
            }
            await _context.SaveChangesAsync();
        }
    }
}
