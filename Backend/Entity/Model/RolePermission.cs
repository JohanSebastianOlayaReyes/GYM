using Entity.Model.Base;

namespace Entity.Model
{
    /// <summary>
    /// Representa la relación muchos a muchos entre roles y permisos.
    /// Define qué permisos específicos tiene asignado cada rol del sistema.
    /// </summary>
    public class RolePermission : BaseEntity
    {
        /// <summary>
        /// Obtiene o establece el identificador del rol.
        /// Clave foránea que referencia a la entidad Role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Obtiene o establece el rol asociado a esta relación.
        /// Propiedad de navegación hacia la entidad Role.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del permiso.
        /// Clave foránea que referencia a la entidad Permission.
        /// </summary>
        public int PermissionId { get; set; }

        /// <summary>
        /// Obtiene o establece el permiso asociado a esta relación.
        /// Propiedad de navegación hacia la entidad Permission.
        /// </summary>
        public Permission Permission { get; set; }
    }
}
