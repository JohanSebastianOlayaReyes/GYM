using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Gym;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements.MembershipData
{
    /// <summary>
    /// Implementación de operaciones de acceso a datos para membresías del gimnasio
    /// </summary>
    public class MembershipData : BaseModelData<Membership>, IMembershipData
    {
        public MembershipData(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene todas las membresías de un usuario específico
        /// </summary>
        public async Task<IEnumerable<Membership>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(m => m.UserId == userId && m.Status)
                .Include(m => m.Service)
                .OrderByDescending(m => m.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas las membresías activas (no expiradas)
        /// </summary>
        public async Task<IEnumerable<Membership>> GetActiveMembershipsAsync()
        {
            var currentDate = DateTime.UtcNow;
            return await _dbSet
                .Where(m => m.Status && m.EndDate >= currentDate)
                .Include(m => m.User)
                .Include(m => m.Service)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas las membresías expiradas
        /// </summary>
        public async Task<IEnumerable<Membership>> GetExpiredMembershipsAsync()
        {
            var currentDate = DateTime.UtcNow;
            return await _dbSet
                .Where(m => m.Status && m.EndDate < currentDate)
                .Include(m => m.User)
                .Include(m => m.Service)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene la membresía actual activa de un usuario
        /// </summary>
        public async Task<Membership> GetCurrentMembershipByUserIdAsync(int userId)
        {
            var currentDate = DateTime.UtcNow;
            return await _dbSet
                .Where(m => m.UserId == userId && m.Status && m.EndDate >= currentDate)
                .Include(m => m.Service)
                .OrderByDescending(m => m.StartDate)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtiene membresías que expiran en los próximos días especificados
        /// </summary>
        public async Task<IEnumerable<Membership>> GetExpiringMembershipsAsync(int daysUntilExpiration)
        {
            var currentDate = DateTime.UtcNow;
            var expirationDate = currentDate.AddDays(daysUntilExpiration);

            return await _dbSet
                .Where(m => m.Status && m.EndDate >= currentDate && m.EndDate <= expirationDate)
                .Include(m => m.User)
                .Include(m => m.Service)
                .OrderBy(m => m.EndDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene membresías por tipo (mensual, semanal, diaria, etc.)
        /// </summary>
        public async Task<IEnumerable<Membership>> GetByTypeAsync(string type)
        {
            return await _dbSet
                .Where(m => m.Status && m.Type.ToLower() == type.ToLower())
                .Include(m => m.User)
                .Include(m => m.Service)
                .ToListAsync();
        }

        /// <summary>
        /// Extiende una membresía agregando días adicionales
        /// </summary>
        public async Task<bool> ExtendMembershipAsync(int membershipId, int additionalDays)
        {
            var membership = await _dbSet.FindAsync(membershipId);
            if (membership == null || !membership.Status)
                return false;

            membership.EndDate = membership.EndDate.AddDays(additionalDays);
            membership.UpdatedAt = DateTime.UtcNow;

            _context.Update(membership);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Verifica si un usuario tiene una membresía activa
        /// </summary>
        public async Task<bool> HasActiveMembershipAsync(int userId)
        {
            var currentDate = DateTime.UtcNow;
            return await _dbSet
                .AnyAsync(m => m.UserId == userId && m.Status && m.EndDate >= currentDate);
        }

        /// <summary>
        /// Obtiene el número total de membresías activas
        /// </summary>
        public async Task<int> GetActiveMembershipsCountAsync()
        {
            var currentDate = DateTime.UtcNow;
            return await _dbSet
                .CountAsync(m => m.Status && m.EndDate >= currentDate);
        }
    }
}
