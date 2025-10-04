using Business.Interfaces;
using Entity.Dtos.PaymentDTO;
using Gym;

namespace Business.Interfaces
{
    public interface IPaymentBusiness : IBaseBusiness<Payment, PaymentDto>
    {
        Task<IEnumerable<PaymentDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<PaymentDto>> GetByMembershipIdAsync(int membershipId);
        Task<IEnumerable<PaymentDto>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalIncomeByMonthAsync(int month, int year);

        /// <summary>
        /// Obtiene pagos por método de pago
        /// </summary>
        /// <param name="method">Método de pago a filtrar</param>
        /// <returns>Lista de pagos realizados con el método especificado</returns>
        Task<IEnumerable<PaymentDto>> GetByPaymentMethodAsync(string method);

        /// <summary>
        /// Obtiene el ingreso total en un rango de fechas
        /// </summary>
        /// <param name="startDate">Fecha inicial</param>
        /// <param name="endDate">Fecha final</param>
        /// <returns>Monto total de ingresos en el rango especificado</returns>
        Task<decimal> GetTotalIncomeByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Obtiene los pagos más recientes
        /// </summary>
        /// <param name="count">Cantidad de pagos a obtener</param>
        /// <returns>Lista de los pagos más recientes</returns>
        Task<IEnumerable<PaymentDto>> GetRecentPaymentsAsync(int count);

        /// <summary>
        /// Obtiene estadísticas de pagos agrupadas por método de pago para un mes específico
        /// </summary>
        /// <param name="month">Mes a consultar</param>
        /// <param name="year">Año a consultar</param>
        /// <returns>Diccionario con el método de pago como clave y el total como valor</returns>
        Task<Dictionary<string, decimal>> GetPaymentStatsByMethodAsync(int month, int year);
    }
}
