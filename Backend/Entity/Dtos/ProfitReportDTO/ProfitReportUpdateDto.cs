using Entity.Dtos.Base;

namespace Entity.Dtos.ProfitReportDTO;

/// <summary>
/// DTO utilizado para actualizar la información de un reporte de ganancias existente
/// </summary>
public class ProfitReportUpdateDto : BaseDto
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
