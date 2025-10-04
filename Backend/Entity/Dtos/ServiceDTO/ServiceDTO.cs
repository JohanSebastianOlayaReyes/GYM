using Entity.Dtos.Base;

namespace Gym;

/// <summary>
/// DTO para representar la información de un servicio del gimnasio.
/// Utilizado en operaciones de creación, lectura y transferencia de datos de servicios.
/// </summary>
public class ServiceDTO : BaseDto
{
    /// <summary>
    /// Nombre del servicio
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Precio del servicio
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Indica si el servicio es una suscripción recurrente
    /// </summary>
    public bool IsSubscription { get; set; }

    /// <summary>
    /// Descripción detallada del servicio
    /// </summary>
    public string Description { get; set; }
}
