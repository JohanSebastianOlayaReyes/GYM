using Gym;

namespace Data.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones de datos específicas de pagos del gimnasio
    /// </summary>
    public interface IPaymentData : IBaseModelData<Payment>
    {
        /// <summary>
        /// Obtiene todos los pagos de un usuario específico
        /// </summary>
        Task<IEnumerable<Payment>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Obtiene todos los pagos asociados a una membresía
        /// </summary>
        Task<IEnumerable<Payment>> GetByMembershipIdAsync(int membershipId);

        /// <summary>
        /// Obtiene pagos dentro de un rango de fechas
        /// </summary>
        Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Obtiene el ingreso total de un mes específico
        /// </summary>
        Task<decimal> GetTotalIncomeByMonthAsync(int month, int year);

        /// <summary>
        /// Obtiene pagos por método de pago
        /// </summary>
        Task<IEnumerable<Payment>> GetByPaymentMethodAsync(string method);

        /// <summary>
        /// Obtiene el ingreso total de un rango de fechas
        /// </summary>
        Task<decimal> GetTotalIncomeByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Obtiene los últimos N pagos realizados
        /// </summary>
        Task<IEnumerable<Payment>> GetRecentPaymentsAsync(int count);

        /// <summary>
        /// Obtiene estadísticas de pagos por método
        /// </summary>
        Task<Dictionary<string, decimal>> GetPaymentStatsByMethodAsync(int month, int year);
    }
}
