using Entity.Dtos.Base;

namespace Gym;

/// <summary>
/// DTO utilizado para actualizar la información de una asistencia registrada
/// </summary>
public class AttendanceUpdateDto : BaseDto
{
    /// <summary>
    /// Identificador del usuario que registró la asistencia
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Fecha de la asistencia
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Hora en que se registró la asistencia
    /// </summary>
    public TimeSpan Time { get; set; }

    /// <summary>
    /// Método utilizado para registrar la asistencia (ID, huella dactilar, código QR, etc.)
    /// </summary>
    public string RegistrationMethod { get; set; } // ID, fingerprint, etc.
}
