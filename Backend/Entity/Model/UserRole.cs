using Entity.Model.Base;

namespace Entity.Model
{
    /// <summary>
    /// Representa la relación muchos a muchos entre usuarios y roles.
    /// Permite asignar múltiples roles a un usuario y que un rol sea compartido por múltiples usuarios.
    /// </summary>
    public class UserRole : BaseEntity
    {
        /// <summary>
        /// Obtiene o establece el identificador del usuario.
        /// Clave foránea que referencia a la entidad User.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del rol.
        /// Clave foránea que referencia a la entidad Role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Obtiene o establece el usuario asociado a esta relación.
        /// Propiedad de navegación hacia la entidad User.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Obtiene o establece el rol asociado a esta relación.
        /// Propiedad de navegación hacia la entidad Role.
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
