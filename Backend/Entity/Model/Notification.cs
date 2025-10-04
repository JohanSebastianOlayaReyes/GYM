using Entity.Model;
using Entity.Model.Base;

namespace Gym;

/// <summary>
/// Representa una notificación enviada a un usuario del sistema.
/// Gestiona comunicaciones sobre vencimientos, promociones, recordatorios y otros eventos importantes.
/// </summary>
public class Notification : BaseEntity
{
    /// <summary>
    /// Obtiene o establece el identificador del usuario destinatario de la notificación.
    /// Clave foránea que referencia a la entidad User.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Obtiene o establece el tipo de notificación.
    /// Valores posibles: 'expiration' (vencimiento), 'promotion' (promoción), 'reminder' (recordatorio), etc.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Obtiene o establece el contenido del mensaje de la notificación.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha y hora en que se envió la notificación.
    /// </summary>
    public DateTime SentDate { get; set; }

    /// <summary>
    /// Obtiene o establece si la notificación ha sido leída por el usuario.
    /// True indica que fue leída, False indica que está pendiente de lectura.
    /// </summary>
    public bool IsRead { get; set; }

    /// <summary>
    /// Obtiene o establece el usuario destinatario de esta notificación.
    /// Propiedad de navegación hacia la entidad User.
    /// </summary>
    public virtual User User { get; set; }
}
