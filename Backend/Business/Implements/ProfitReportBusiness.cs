using AutoMapper;
using Business.Implements;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.ProfitReportDTO;
using Gym;
using Microsoft.Extensions.Logging;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class ProfitReportBusiness : BaseBusiness<ProfitReport, ProfitReportDto>, IProfitReportBusiness
    {
        private readonly IProfitReportData _profitReportData;

        public ProfitReportBusiness(
            IProfitReportData data,
            IMapper mapper,
            ILogger<ProfitReportBusiness> logger,
            IGenericIHelpers helpers)
            : base(data, mapper, logger, helpers)
        {
            _profitReportData = data;
        }

        public async Task<ProfitReportDto> GetByMonthYearAsync(int month, int year)
        {
            try
            {
                var report = await _profitReportData.GetByMonthYearAsync(month, year);
                return _mapper.Map<ProfitReportDto>(report);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener reporte de {month}/{year}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<ProfitReportDto>> GetByYearAsync(int year)
        {
            try
            {
                var reports = await _profitReportData.GetByYearAsync(year);
                return _mapper.Map<IEnumerable<ProfitReportDto>>(reports);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener reportes del año {year}: {ex.Message}");
                throw;
            }
        }

        public async Task<ProfitReportDto> GenerateReportAsync(int month, int year)
        {
            try
            {
                var report = await _profitReportData.GenerateReportAsync(month, year);
                return _mapper.Map<ProfitReportDto>(report);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al generar reporte de {month}/{year}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Compara los reportes de ganancias de dos años diferentes
        /// </summary>
        /// <param name="year1">Primer año a comparar</param>
        /// <param name="year2">Segundo año a comparar</param>
        /// <returns>Diccionario con los reportes de ambos años agrupados por mes</returns>
        public async Task<Dictionary<int, (ProfitReportDto Year1, ProfitReportDto Year2)>> GetComparisonByYearAsync(int year1, int year2)
        {
            try
            {
                var comparison = await _profitReportData.GetComparisonByYearAsync(year1, year2);

                var result = new Dictionary<int, (ProfitReportDto Year1, ProfitReportDto Year2)>();

                foreach (var kvp in comparison)
                {
                    result[kvp.Key] = (
                        _mapper.Map<ProfitReportDto>(kvp.Value.Year1),
                        _mapper.Map<ProfitReportDto>(kvp.Value.Year2)
                    );
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al comparar reportes de años {year1} y {year2}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el total de ganancias de un año completo
        /// </summary>
        /// <param name="year">Año a consultar</param>
        /// <returns>Total de ganancias del año</returns>
        public async Task<decimal> GetYearlyTotalAsync(int year)
        {
            try
            {
                return await _profitReportData.GetYearlyTotalAsync(year);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener total de ganancias del año {year}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el mes con mayores ganancias de un año específico
        /// </summary>
        /// <param name="year">Año a consultar</param>
        /// <returns>El reporte del mes con mayores ganancias</returns>
        public async Task<ProfitReportDto> GetBestMonthAsync(int year)
        {
            try
            {
                var report = await _profitReportData.GetBestMonthAsync(year);
                return _mapper.Map<ProfitReportDto>(report);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el mejor mes del año {year}: {ex.Message}");
                throw;
            }
        }
    }
}
