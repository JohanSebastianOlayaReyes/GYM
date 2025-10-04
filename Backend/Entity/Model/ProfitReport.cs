using Entity.Model.Base;

namespace Gym;

/// <summary>
/// Representa un reporte de ganancias del gimnasio para un periodo específico.
/// Consolida los ingresos mensuales y mantiene el detalle de los pagos asociados.
/// </summary>
public class ProfitReport : BaseEntity
{
    /// <summary>
    /// Obtiene o establece el número del mes del reporte (1-12).
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// Obtiene o establece el año del reporte.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Obtiene o establece el ingreso total acumulado para el periodo especificado.
    /// Representa la suma de todos los pagos recibidos en el mes y año indicados.
    /// </summary>
    public decimal TotalIncome { get; set; }

    /// <summary>
    /// Obtiene o establece la colección de pagos que conforman el reporte.
    /// Incluye todos los pagos individuales que contribuyen al ingreso total del periodo.
    /// </summary>
    public virtual ICollection<Payment> PaymentDetails { get; set; }

}
