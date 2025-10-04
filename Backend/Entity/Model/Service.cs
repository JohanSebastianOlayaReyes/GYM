using Entity.Model.Base;

namespace Gym;

/// <summary>
/// Representa un servicio o plan ofrecido por el gimnasio.
/// Puede ser una suscripción recurrente o un servicio de pago único.
/// </summary>
public class Service : BaseEntity
{
    /// <summary>
    /// Obtiene o establece el nombre del servicio (ej: Plan Mensual, Clase de Yoga, etc.).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Obtiene o establece el precio del servicio en la moneda local.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Obtiene o establece si el servicio es una suscripción recurrente.
    /// True indica que es una suscripción periódica, False indica que es un pago único.
    /// </summary>
    public bool IsSubscription { get; set; }

    /// <summary>
    /// Obtiene o establece la descripción detallada del servicio.
    /// Incluye información sobre los beneficios, restricciones y características del servicio.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Obtiene o establece la colección de membresías asociadas a este servicio.
    /// Representa todos los usuarios que han adquirido o están utilizando este servicio.
    /// </summary>
    public virtual ICollection<Membership> Memberships { get; set; }

}
