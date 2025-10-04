using Entity.Dtos.Base;

namespace Gym;

/// <summary>
/// DTO utilizado para realizar la eliminación lógica de un pago.
/// Establece el estado del pago como inactivo sin eliminarlo físicamente de la base de datos.
/// </summary>
public class DeleteLogicalPaymentDto : BaseDto
{
    /// <summary>
    /// Constructor que inicializa el estado del pago como inactivo (false)
    /// </summary>
    public DeleteLogicalPaymentDto()
    {
        Status = false;
    }
}
