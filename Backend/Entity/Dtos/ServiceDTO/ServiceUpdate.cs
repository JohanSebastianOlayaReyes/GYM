using Entity.Dtos.Base;

namespace Gym;

/// <summary>
/// DTO utilizado para actualizar la información de un servicio existente en el gimnasio
/// </summary>
public class ServiceUpdate : BaseDto
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
