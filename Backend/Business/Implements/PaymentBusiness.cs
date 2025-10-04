using AutoMapper;
using Business.Implements;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.PaymentDTO;
using Gym;
using Microsoft.Extensions.Logging;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class PaymentBusiness : BaseBusiness<Payment, PaymentDto>, IPaymentBusiness
    {
        private readonly IPaymentData _paymentData;

        public PaymentBusiness(
            IPaymentData data,
            IMapper mapper,
            ILogger<PaymentBusiness> logger,
            IGenericIHelpers helpers)
            : base(data, mapper, logger, helpers)
        {
            _paymentData = data;
        }

        public async Task<IEnumerable<PaymentDto>> GetByUserIdAsync(int userId)
        {
            try
            {
                var payments = await _paymentData.GetByUserIdAsync(userId);
                return _mapper.Map<IEnumerable<PaymentDto>>(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener pagos del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<PaymentDto>> GetByMembershipIdAsync(int membershipId)
        {
            try
            {
                var payments = await _paymentData.GetByMembershipIdAsync(membershipId);
                return _mapper.Map<IEnumerable<PaymentDto>>(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener pagos de la membresía {membershipId}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var payments = await _paymentData.GetPaymentsByDateRangeAsync(startDate, endDate);
                return _mapper.Map<IEnumerable<PaymentDto>>(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener pagos por rango de fechas: {ex.Message}");
                throw;
            }
        }

        public async Task<decimal> GetTotalIncomeByMonthAsync(int month, int year)
        {
            try
            {
                return await _paymentData.GetTotalIncomeByMonthAsync(month, year);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener ingresos totales del mes {month}/{year}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene pagos por método de pago
        /// </summary>
        /// <param name="method">Método de pago a filtrar</param>
        /// <returns>Lista de pagos realizados con el método especificado</returns>
        public async Task<IEnumerable<PaymentDto>> GetByPaymentMethodAsync(string method)
        {
            try
            {
                var payments = await _paymentData.GetByPaymentMethodAsync(method);
                return _mapper.Map<IEnumerable<PaymentDto>>(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener pagos por método '{method}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el ingreso total en un rango de fechas
        /// </summary>
        /// <param name="startDate">Fecha inicial</param>
        /// <param name="endDate">Fecha final</param>
        /// <returns>Monto total de ingresos en el rango especificado</returns>
        public async Task<decimal> GetTotalIncomeByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _paymentData.GetTotalIncomeByDateRangeAsync(startDate, endDate);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener ingresos totales por rango de fechas: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene los pagos más recientes
        /// </summary>
        /// <param name="count">Cantidad de pagos a obtener</param>
        /// <returns>Lista de los pagos más recientes</returns>
        public async Task<IEnumerable<PaymentDto>> GetRecentPaymentsAsync(int count)
        {
            try
            {
                var payments = await _paymentData.GetRecentPaymentsAsync(count);
                return _mapper.Map<IEnumerable<PaymentDto>>(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los {count} pagos más recientes: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene estadísticas de pagos agrupadas por método de pago para un mes específico
        /// </summary>
        /// <param name="month">Mes a consultar</param>
        /// <param name="year">Año a consultar</param>
        /// <returns>Diccionario con el método de pago como clave y el total como valor</returns>
        public async Task<Dictionary<string, decimal>> GetPaymentStatsByMethodAsync(int month, int year)
        {
            try
            {
                return await _paymentData.GetPaymentStatsByMethodAsync(month, year);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener estadísticas de pagos por método del mes {month}/{year}: {ex.Message}");
                throw;
            }
        }
    }
}
