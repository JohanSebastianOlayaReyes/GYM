using Entity.Dtos.Base;

namespace Gym;

/// <summary>
/// DTO para representar la información de una asistencia al gimnasio.
/// Utilizado en operaciones de creación, lectura y transferencia de datos de asistencias.
/// </summary>
public class AttendanceDto : BaseDto
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
