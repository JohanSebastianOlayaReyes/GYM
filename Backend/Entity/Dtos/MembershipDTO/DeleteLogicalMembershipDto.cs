using Entity.Dtos.Base;

namespace Entity.Dtos.MembershipDTO;

/// <summary>
/// DTO utilizado para realizar la eliminación lógica de una membresía.
/// Establece el estado de la membresía como inactivo sin eliminarla físicamente de la base de datos.
/// </summary>
public class DeleteLogicalMembershipDto : BaseDto
{
    /// <summary>
    /// Constructor que inicializa el estado de la membresía como inactivo (false)
    /// </summary>
    public DeleteLogicalMembershipDto()
    {
        Status = false;
    }
}
