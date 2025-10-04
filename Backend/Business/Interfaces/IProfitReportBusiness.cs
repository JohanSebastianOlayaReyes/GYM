using Business.Interfaces;
using Entity.Dtos.ProfitReportDTO;
using Gym;

namespace Business.Interfaces
{
    public interface IProfitReportBusiness : IBaseBusiness<ProfitReport, ProfitReportDto>
    {
        Task<ProfitReportDto> GetByMonthYearAsync(int month, int year);
        Task<IEnumerable<ProfitReportDto>> GetByYearAsync(int year);
        Task<ProfitReportDto> GenerateReportAsync(int month, int year);

        /// <summary>
        /// Compara los reportes de ganancias de dos años diferentes
        /// </summary>
        /// <param name="year1">Primer año a comparar</param>
        /// <param name="year2">Segundo año a comparar</param>
        /// <returns>Diccionario con los reportes de ambos años agrupados por mes</returns>
        Task<Dictionary<int, (ProfitReportDto Year1, ProfitReportDto Year2)>> GetComparisonByYearAsync(int year1, int year2);

        /// <summary>
        /// Obtiene el total de ganancias de un año completo
        /// </summary>
        /// <param name="year">Año a consultar</param>
        /// <returns>Total de ganancias del año</returns>
        Task<decimal> GetYearlyTotalAsync(int year);

        /// <summary>
        /// Obtiene el mes con mayores ganancias de un año específico
        /// </summary>
        /// <param name="year">Año a consultar</param>
        /// <returns>El reporte del mes con mayores ganancias</returns>
        Task<ProfitReportDto> GetBestMonthAsync(int year);
    }
}
