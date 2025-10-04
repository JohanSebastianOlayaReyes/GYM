using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Gym;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements.ProfitReportData
{
    public class ProfitReportData : BaseModelData<ProfitReport>, IProfitReportData
    {
        private readonly IPaymentData _paymentData;

        public ProfitReportData(ApplicationDbContext context, IPaymentData paymentData) : base(context)
        {
            _paymentData = paymentData;
        }

        public async Task<ProfitReport> GetByMonthYearAsync(int month, int year)
        {
            return await _dbSet
                .FirstOrDefaultAsync(pr => pr.Month == month && pr.Year == year && pr.Status);
        }

        public async Task<IEnumerable<ProfitReport>> GetByYearAsync(int year)
        {
            return await _dbSet
                .Where(pr => pr.Year == year && pr.Status)
                .OrderBy(pr => pr.Month)
                .ToListAsync();
        }

        public async Task<ProfitReport> GenerateReportAsync(int month, int year)
        {
            var totalIncome = await _paymentData.GetTotalIncomeByMonthAsync(month, year);

            var existingReport = await GetByMonthYearAsync(month, year);

            if (existingReport != null)
            {
                existingReport.TotalIncome = totalIncome;
                existingReport.UpdatedAt = DateTime.UtcNow;
                await UpdateAsync(existingReport);
                return existingReport;
            }

            var newReport = new ProfitReport
            {
                Month = month,
                Year = year,
                TotalIncome = totalIncome,
                Status = true,
                CreatedAt = DateTime.UtcNow
            };

            return await CreateAsync(newReport);
        }

        /// <summary>
        /// Compara los ingresos totales entre dos años específicos
        /// </summary>
        /// <param name="year1">Primer año a comparar</param>
        /// <param name="year2">Segundo año a comparar</param>
        /// <returns>Un objeto anónimo con los totales de ambos años y la diferencia</returns>
        public async Task<object> GetComparisonByYearAsync(int year1, int year2)
        {
            var totalYear1 = await GetYearlyTotalAsync(year1);
            var totalYear2 = await GetYearlyTotalAsync(year2);
            var difference = totalYear2 - totalYear1;

            return new
            {
                Year1 = year1,
                TotalYear1 = totalYear1,
                Year2 = year2,
                TotalYear2 = totalYear2,
                Difference = difference,
                PercentageChange = totalYear1 > 0 ? (difference / totalYear1) * 100 : 0
            };
        }

        /// <summary>
        /// Obtiene el total de ingresos de un año específico
        /// </summary>
        /// <param name="year">Año del cual obtener el total</param>
        /// <returns>El total de ingresos del año</returns>
        public async Task<decimal> GetYearlyTotalAsync(int year)
        {
            var reports = await _dbSet
                .Where(pr => pr.Year == year && pr.Status)
                .ToListAsync();

            return reports.Sum(pr => pr.TotalIncome);
        }

        /// <summary>
        /// Obtiene el mes con mayores ingresos en un año específico
        /// </summary>
        /// <param name="year">Año del cual obtener el mejor mes</param>
        /// <returns>El reporte del mes con mayores ingresos</returns>
        public async Task<ProfitReport> GetBestMonthAsync(int year)
        {
            return await _dbSet
                .Where(pr => pr.Year == year && pr.Status)
                .OrderByDescending(pr => pr.TotalIncome)
                .FirstOrDefaultAsync();
        }
    }
}
