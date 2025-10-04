using Entity.Model;
using Entity.Model.Base;

namespace Gym;

/// <summary>
/// Representa una membresía o suscripción de un usuario a un servicio del gimnasio.
/// Define el periodo de validez y el tipo de membresía adquirida.
/// </summary>
public class Membership : BaseEntity
{
    /// <summary>
    /// Obtiene o establece el identificador del usuario propietario de la membresía.
    /// Clave foránea que referencia a la entidad User.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Obtiene o establece el tipo de membresía.
    /// Valores posibles: monthly (mensual), biweekly (quincenal), daily (diario), trial (prueba), etc.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha de inicio de vigencia de la membresía.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha de finalización de vigencia de la membresía.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador del servicio asociado a la membresía.
    /// Clave foránea que referencia a la entidad Service.
    /// </summary>
    public int ServiceId { get; set; }

    /// <summary>
    /// Obtiene o establece el usuario propietario de esta membresía.
    /// Propiedad de navegación hacia la entidad User.
    /// </summary>
    public virtual User User { get; set; }

    /// <summary>
    /// Obtiene o establece el servicio asociado a esta membresía.
    /// Propiedad de navegación hacia la entidad Service.
    /// </summary>
    public virtual Service Service { get; set; }

    /// <summary>
    /// Obtiene o establece la colección de pagos realizados para esta membresía.
    /// Incluye todos los pagos asociados al periodo de la membresía.
    /// </summary>
    public virtual ICollection<Payment> Payments { get; set; }
}