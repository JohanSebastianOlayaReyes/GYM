using Entity.Dtos.Base;

namespace Gym;

/// <summary>
/// DTO para representar la información de una membresía de gimnasio.
/// Utilizado en operaciones de creación, lectura y transferencia de datos de membresías.
/// </summary>
public class MembershipDto : BaseDto
{
    /// <summary>
    /// Identificador del usuario asociado a la membresía
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Tipo de membresía (mensual, quincenal, diaria, prueba, etc.)
    /// </summary>
    public string Type { get; set; } // monthly, biweekly, daily, trial, etc.

    /// <summary>
    /// Fecha de inicio de la membresía
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Fecha de finalización de la membresía
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Identificador del servicio asociado a la membresía
    /// </summary>
    public int ServiceId { get; set; }
}
