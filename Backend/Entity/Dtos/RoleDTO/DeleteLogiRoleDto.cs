using Entity.Dtos.Base;

namespace Entity.Dtos.RolDTO
{
    /// <summary>
    /// DTO utilizado para realizar la eliminación lógica de un rol.
    /// Establece el estado del rol como inactivo sin eliminarlo físicamente de la base de datos.
    /// </summary>
    public class DeleteLogicalRoleDto : BaseDto
    {
        /// <summary>
        /// Constructor que inicializa el estado del rol como inactivo (false)
        /// </summary>
        public DeleteLogicalRoleDto()
        {
            Status = false;
        }
    }
}
