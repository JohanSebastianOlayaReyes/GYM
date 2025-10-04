using Entity.Dtos.Base;

namespace Entity.Dtos.UserRoleDTO
{
    /// <summary>
    /// DTO utilizado para realizar la eliminación lógica de una asignación de rol a usuario.
    /// Establece el estado de la relación usuario-rol como inactivo sin eliminarla físicamente de la base de datos.
    /// </summary>
    public class DeleteLogicalUserRoleDto : BaseDto
    {
        /// <summary>
        /// Constructor que inicializa el estado de la asignación como inactivo (false)
        /// </summary>
        public DeleteLogicalUserRoleDto()
        {
            Status = false;
        }
    }
}
