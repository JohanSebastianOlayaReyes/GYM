using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Gym;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements.PaymentData
{
    /// <summary>
    /// Implementación de operaciones de acceso a datos para pagos del gimnasio
    /// </summary>
    public class PaymentData : BaseModelData<Payment>, IPaymentData
    {
        public PaymentData(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene todos los pagos de un usuario específico
        /// </summary>
        public async Task<IEnumerable<Payment>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(p => p.UserId == userId && p.Status)
                .Include(p => p.Membership)
                .ThenInclude(m => m.Service)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los pagos asociados a una membresía
        /// </summary>
        public async Task<IEnumerable<Payment>> GetByMembershipIdAsync(int membershipId)
        {
            return await _dbSet
                .Where(p => p.MembershipId == membershipId && p.Status)
                .Include(p => p.User)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene pagos dentro de un rango de fechas
        /// </summary>
        public async Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(p => p.Status && p.Date >= startDate && p.Date <= endDate)
                .Include(p => p.User)
                .Include(p => p.Membership)
                .ThenInclude(m => m.Service)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene el ingreso total de un mes específico
        /// </summary>
        public async Task<decimal> GetTotalIncomeByMonthAsync(int month, int year)
        {
            var total = await _dbSet
                .Where(p => p.Status && p.Date.Month == month && p.Date.Year == year)
                .SumAsync(p => (decimal?)p.Amount);

            return total ?? 0;
        }

        /// <summary>
        /// Obtiene pagos por método de pago
        /// </summary>
        public async Task<IEnumerable<Payment>> GetByPaymentMethodAsync(string method)
        {
            return await _dbSet
                .Where(p => p.Status && p.Method.ToLower() == method.ToLower())
                .Include(p => p.User)
                .Include(p => p.Membership)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene el ingreso total de un rango de fechas
        /// </summary>
        public async Task<decimal> GetTotalIncomeByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var total = await _dbSet
                .Where(p => p.Status && p.Date >= startDate && p.Date <= endDate)
                .SumAsync(p => (decimal?)p.Amount);

            return total ?? 0;
        }

        /// <summary>
        /// Obtiene los últimos N pagos realizados
        /// </summary>
        public async Task<IEnumerable<Payment>> GetRecentPaymentsAsync(int count)
        {
            return await _dbSet
                .Where(p => p.Status)
                .Include(p => p.User)
                .Include(p => p.Membership)
                .ThenInclude(m => m.Service)
                .OrderByDescending(p => p.Date)
                .Take(count)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene estadísticas de pagos por método
        /// </summary>
        public async Task<Dictionary<string, decimal>> GetPaymentStatsByMethodAsync(int month, int year)
        {
            return await _dbSet
                .Where(p => p.Status && p.Date.Month == month && p.Date.Year == year)
                .GroupBy(p => p.Method)
                .Select(g => new { Method = g.Key, Total = g.Sum(p => p.Amount) })
                .ToDictionaryAsync(x => x.Method, x => x.Total);
        }
    }
}
