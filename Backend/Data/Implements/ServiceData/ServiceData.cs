using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Gym;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements.ServiceData
{
    /// <summary>
    /// Implementación de operaciones de acceso a datos para servicios del gimnasio
    /// </summary>
    public class ServiceData : BaseModelData<Service>, IServiceData
    {
        public ServiceData(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene todos los servicios activos
        /// </summary>
        public async Task<IEnumerable<Service>> GetActiveServicesAsync()
        {
            return await _dbSet.Where(s => s.Status).ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los servicios que son de tipo suscripción
        /// </summary>
        public async Task<IEnumerable<Service>> GetSubscriptionServicesAsync()
        {
            return await _dbSet.Where(s => s.IsSubscription && s.Status).ToListAsync();
        }

        /// <summary>
        /// Obtiene un servicio por su nombre
        /// </summary>
        public async Task<Service> GetByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower() && s.Status);
        }

        /// <summary>
        /// Obtiene servicios dentro de un rango de precio
        /// </summary>
        public async Task<IEnumerable<Service>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _dbSet
                .Where(s => s.Status && s.Price >= minPrice && s.Price <= maxPrice)
                .OrderBy(s => s.Price)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene el servicio más popular basado en el número de membresías activas
        /// </summary>
        public async Task<Service> GetMostPopularServiceAsync()
        {
            var currentDate = DateTime.UtcNow;
            return await _dbSet
                .Include(s => s.Memberships)
                .Where(s => s.Status)
                .OrderByDescending(s => s.Memberships.Count(m => m.Status && m.EndDate >= currentDate))
                .FirstOrDefaultAsync();
        }
    }
}
