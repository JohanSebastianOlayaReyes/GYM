using Gym;

namespace Data.Interfaces
{
    public interface IProfitReportData : IBaseModelData<ProfitReport>
    {
        Task<ProfitReport> GetByMonthYearAsync(int month, int year);
        Task<IEnumerable<ProfitReport>> GetByYearAsync(int year);
        Task<ProfitReport> GenerateReportAsync(int month, int year);

        /// <summary>
        /// Compara los ingresos totales entre dos años específicos
        /// </summary>
        /// <param name="year1">Primer año a comparar</param>
        /// <param name="year2">Segundo año a comparar</param>
        /// <returns>Un objeto anónimo con los totales de ambos años y la diferencia</returns>
        Task<object> GetComparisonByYearAsync(int year1, int year2);

        /// <summary>
        /// Obtiene el total de ingresos de un año específico
        /// </summary>
        /// <param name="year">Año del cual obtener el total</param>
        /// <returns>El total de ingresos del año</returns>
        Task<decimal> GetYearlyTotalAsync(int year);

        /// <summary>
        /// Obtiene el mes con mayores ingresos en un año específico
        /// </summary>
        /// <param name="year">Año del cual obtener el mejor mes</param>
        /// <returns>El reporte del mes con mayores ingresos</returns>
        Task<ProfitReport> GetBestMonthAsync(int year);
    }
}
