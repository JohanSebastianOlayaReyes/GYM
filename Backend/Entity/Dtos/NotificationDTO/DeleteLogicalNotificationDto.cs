using Entity.Dtos.Base;

namespace Gym;

/// <summary>
/// DTO utilizado para realizar la eliminación lógica de una notificación.
/// Establece el estado de la notificación como inactivo sin eliminarla físicamente de la base de datos.
/// </summary>
public class DeleteLogicalNotificationDto : BaseDto
{
    /// <summary>
    /// Constructor que inicializa el estado de la notificación como inactivo (false)
    /// </summary>
    public DeleteLogicalNotificationDto()
    {
        Status = false;
    }
}
