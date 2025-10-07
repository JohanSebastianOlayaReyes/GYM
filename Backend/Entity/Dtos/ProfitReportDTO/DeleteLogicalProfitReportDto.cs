using Entity.Dtos.Base;

namespace Entity.Dtos.ProfitReportDTO;

/// <summary>
/// DTO utilizado para realizar la eliminación lógica de un reporte de ganancias.
/// Establece el estado del reporte como inactivo sin eliminarlo físicamente de la base de datos.
/// </summary>
public class DeleteLogicalProfitReportDto : BaseDto
{
    /// <summary>
    /// Constructor que inicializa el estado del reporte como inactivo (false)
    /// </summary>
    public DeleteLogicalProfitReportDto()
    {
        Status = false;
    }
}
