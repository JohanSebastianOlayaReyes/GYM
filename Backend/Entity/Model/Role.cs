using Entity.Model.Base;

namespace Entity.Model
{
    /// <summary>
    /// Representa un rol del sistema de control de acceso.
    /// Define los diferentes niveles de acceso y responsabilidades de los usuarios.
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// Obtiene o establece el nombre del rol.
        /// Valores comunes: 'Admin' (administrador), 'Employee' (empleado), 'Client' (cliente), etc.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción detallada del rol.
        /// Explica las responsabilidades y alcance del rol dentro del sistema.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de usuarios asignados a este rol.
        /// Representa la relación muchos a muchos con la entidad User a través de UserRole.
        /// </summary>
        public virtual ICollection<UserRole> Users { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de permisos asignados a este rol.
        /// Representa la relación muchos a muchos con la entidad Permission a través de RolePermission.
        /// </summary>
        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
