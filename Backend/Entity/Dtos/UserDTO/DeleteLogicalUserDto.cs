using Entity.Dtos.Base;

namespace Entity.Dtos.UserDTO
{
    /// <summary>
    /// DTO para mostrar información básica de un usuario (operación Delete permanente)
    /// </summary>
    public class DeleteLogicalUserDto : BaseDto
    {
        public DeleteLogicalUserDto()
        {
            Status = false;
        }
    }
}
