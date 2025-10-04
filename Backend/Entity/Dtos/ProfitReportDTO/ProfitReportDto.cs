using Entity.Dtos.Base;

namespace Gym;

/// <summary>
/// DTO para representar un reporte de ganancias del gimnasio.
/// Utilizado en operaciones de creación, lectura y transferencia de datos de reportes financieros.
/// </summary>
public class ProfitReportDto : BaseDto
{
    /// <summary>
    /// Mes del reporte (1-12)
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// Año del reporte
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Ingreso total acumulado en el período especificado
    /// </summary>
    public decimal TotalIncome { get; set; }
}
