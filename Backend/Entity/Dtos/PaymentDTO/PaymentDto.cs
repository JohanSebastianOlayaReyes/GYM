using Entity.Dtos.Base;

namespace Entity.Dtos.PaymentDTO;

/// <summary>
/// DTO para representar la información de un pago realizado en el gimnasio.
/// Utilizado en operaciones de creación, lectura y transferencia de datos de pagos.
/// </summary>
public class PaymentDto : BaseDto
{
    /// <summary>
    /// Identificador del usuario que realiza el pago
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Identificador de la membresía asociada al pago
    /// </summary>
    public int MembershipId { get; set; }

    /// <summary>
    /// Monto del pago
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Fecha en que se realizó el pago
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Método de pago utilizado (efectivo, tarjeta, transferencia, etc.)
    /// </summary>
    public string Method { get; set; } // 'cash'

    /// <summary>
    /// Referencia o número de comprobante del pago
    /// </summary>
    public string Reference { get; set; }
}
