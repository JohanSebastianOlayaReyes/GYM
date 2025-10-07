using Entity.Model.Base;
using Gym;

namespace Entity.Model
{
    /// <summary>
    /// Representa un usuario del sistema del gimnasio, que puede ser un cliente, empleado o administrador.
    /// Gestiona la información personal y las relaciones con membresías, pagos, asistencias y notificaciones.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Obtiene o establece el primer nombre del usuario.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del usuario.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Obtiene o establece el número de identificación del usuario (cédula, pasaporte, etc.).
        /// </summary>
        public string Identification { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono de contacto del usuario.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección de correo electrónico del usuario.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtiene o establece el hash de la contraseña del usuario.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en que el usuario se registró en el sistema.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la membresía actual activa del usuario.
        /// Puede ser nulo si el usuario no tiene una membresía activa.
        /// </summary>
        public int? CurrentMembershipId { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de roles asignados al usuario.
        /// Representa la relación muchos a muchos con la entidad Role a través de UserRole.
        /// </summary>
        public virtual ICollection<UserRole> Roles { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de membresías asociadas al usuario.
        /// Incluye todas las membresías históricas y actuales del usuario.
        /// </summary>
        public virtual ICollection<Membership> Memberships { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de pagos realizados por el usuario.
        /// Incluye todos los pagos históricos relacionados con membresías y servicios.
        /// </summary>
        public virtual ICollection<Payment> Payments { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de registros de asistencia del usuario al gimnasio.
        /// Permite el seguimiento del historial de visitas del usuario.
        /// </summary>
        public virtual ICollection<Attendance> Attendances { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de notificaciones enviadas al usuario.
        /// Incluye notificaciones de vencimiento, promociones, recordatorios, etc.
        /// </summary>
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
