using Entity.Model.Base;

namespace Entity.Model
{
    /// <summary>
    /// Representa un permiso específico dentro del sistema de control de acceso.
    /// Define las acciones que pueden ser autorizadas a los diferentes roles.
    /// </summary>
    public class Permission : BaseEntity
    {
        /// <summary>
        /// Obtiene o establece el nombre del permiso.
        /// Valores comunes: 'MANAGE_USERS' (gestionar usuarios), 'MANAGE_SERVICES' (gestionar servicios),
        /// 'VIEW_REPORTS' (ver reportes), etc.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción detallada del permiso.
        /// Explica qué acciones o funcionalidades habilita este permiso.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de roles que tienen asignado este permiso.
        /// Representa la relación muchos a muchos con la entidad Role a través de RolePermission.
        /// </summary>
        public virtual ICollection<RolePermission> Roles { get; set; }
    }
}
