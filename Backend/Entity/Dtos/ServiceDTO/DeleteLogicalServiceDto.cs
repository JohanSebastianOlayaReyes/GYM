using Entity.Dtos.Base;

namespace Entity.Dtos.ServiceDTO;

/// <summary>
/// DTO utilizado para realizar la eliminación lógica de un servicio.
/// Establece el estado del servicio como inactivo sin eliminarlo físicamente de la base de datos.
/// </summary>
public class DeleteLogicalServiceDto : BaseDto
{
    /// <summary>
    /// Constructor que inicializa el estado del servicio como inactivo (false)
    /// </summary>
    public DeleteLogicalServiceDto()
    {
        Status = false;
    }

}
