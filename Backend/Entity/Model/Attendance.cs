using Entity.Model;
using Entity.Model.Base;

namespace Gym;

/// <summary>
/// Representa un registro de asistencia de un usuario al gimnasio.
/// Permite el seguimiento de las visitas y el control de acceso.
/// </summary>
public class Attendance : BaseEntity
{
    /// <summary>
    /// Obtiene o establece el identificador del usuario que registró la asistencia.
    /// Clave foránea que referencia a la entidad User.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha en que se registró la asistencia.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Obtiene o establece la hora en que se registró la asistencia.
    /// </summary>
    public TimeSpan Time { get; set; }

    /// <summary>
    /// Obtiene o establece el método utilizado para registrar la asistencia.
    /// Valores posibles: 'Manual' (ingreso manual), 'QR Code' (código QR), 'Card' (tarjeta de acceso), etc.
    /// </summary>
    public string RegistrationMethod { get; set; }

    /// <summary>
    /// Obtiene o establece el usuario asociado a este registro de asistencia.
    /// Propiedad de navegación hacia la entidad User.
    /// </summary>
    public virtual User User { get; set; }

}
