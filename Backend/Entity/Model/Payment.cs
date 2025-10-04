using Entity.Model;
using Entity.Model.Base;

namespace Gym;

/// <summary>
/// Representa un pago realizado por un usuario para una membresía específica.
/// Almacena información sobre el monto, fecha, método de pago y referencia de la transacción.
/// </summary>
public class Payment : BaseEntity
{
    /// <summary>
    /// Obtiene o establece el identificador del usuario que realizó el pago.
    /// Clave foránea que referencia a la entidad User.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Obtiene o establece el identificador de la membresía por la cual se realizó el pago.
    /// Clave foránea que referencia a la entidad Membership.
    /// </summary>
    public int MembershipId { get; set; }

    /// <summary>
    /// Obtiene o establece el monto del pago en la moneda local.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha en que se realizó el pago.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Obtiene o establece el método de pago utilizado.
    /// Valores posibles: 'cash' (efectivo), 'card' (tarjeta), 'transfer' (transferencia), etc.
    /// </summary>
    public string Method { get; set; }

    /// <summary>
    /// Obtiene o establece la referencia o número de transacción del pago.
    /// Este campo es opcional y se utiliza para pagos electrónicos o transferencias.
    /// </summary>
    public string Reference { get; set; }

    /// <summary>
    /// Obtiene o establece el usuario que realizó el pago.
    /// Propiedad de navegación hacia la entidad User.
    /// </summary>
    public virtual User User { get; set; }

    /// <summary>
    /// Obtiene o establece la membresía asociada a este pago.
    /// Propiedad de navegación hacia la entidad Membership.
    /// </summary>
    public virtual Membership Membership { get; set; }
}
