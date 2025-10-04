using Entity.Dtos.Base;

namespace Entity.Dtos.UserDTO
{
    /// <summary>
    /// DTO utilizado para realizar la eliminación lógica de un usuario.
    /// Establece el estado del usuario como inactivo sin eliminarlo físicamente de la base de datos.
    /// </summary>
    public class DeleteLogicalUserDto : BaseDto
    {
        /// <summary>
        /// Constructor que inicializa el estado del usuario como inactivo (false)
        /// </summary>
        public DeleteLogicalUserDto()
        {
            Status = false;
        }
    }
}
