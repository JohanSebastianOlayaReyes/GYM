using Entity.Dtos.Base;

namespace Entity.Dtos.RolDTO
{
    /// <summary>
    /// DTO utilizado para actualizar la información de un rol existente
    /// </summary>
    public class UpdateRoleDto : BaseDto
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
