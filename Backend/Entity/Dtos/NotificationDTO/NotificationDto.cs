using Entity.Dtos.Base;

namespace Entity.Dtos.NotificationDTO;

/// <summary>
/// DTO para representar la información de una notificación enviada a los usuarios.
/// Utilizado en operaciones de creación, lectura y transferencia de datos de notificaciones.
/// </summary>
public class NotificationDto : BaseDto
{
    /// <summary>
    /// Identificador del usuario destinatario de la notificación
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Tipo de notificación (expiración, promoción, recordatorio, etc.)
    /// </summary>
    public string Type { get; set; } // expiration, promotion, reminder, etc.

    /// <summary>
    /// Mensaje de la notificación
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Fecha y hora en que se envió la notificación
    /// </summary>
    public DateTime SentDate { get; set; }
}