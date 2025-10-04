using Entity.Dtos.Base;

namespace Entity.Dtos.RolDTO
{
    /// <summary>
    /// DTO para representar la información de un rol del sistema.
    /// Utilizado en operaciones de creación, lectura y transferencia de datos de roles.
    /// </summary>
    public class RoleDto : BaseDto
    {
        /// <summary>
        /// Nombre del rol
        /// </summary>
        public  string Name { get; set; }

        /// <summary>
        /// Descripción detallada del rol y sus responsabilidades
        /// </summary>
        public  string Description { get; set; }
    }
}
