using Gym;

namespace Data.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones de datos específicas de servicios del gimnasio
    /// </summary>
    public interface IServiceData : IBaseModelData<Service>
    {
        /// <summary>
        /// Obtiene todos los servicios activos
        /// </summary>
        Task<IEnumerable<Service>> GetActiveServicesAsync();

        /// <summary>
        /// Obtiene todos los servicios que son de tipo suscripción
        /// </summary>
        Task<IEnumerable<Service>> GetSubscriptionServicesAsync();

        /// <summary>
        /// Obtiene un servicio por su nombre
        /// </summary>
        Task<Service> GetByNameAsync(string name);

        /// <summary>
        /// Obtiene servicios dentro de un rango de precio
        /// </summary>
        Task<IEnumerable<Service>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);

        /// <summary>
        /// Obtiene el servicio más popular (más membresías activas)
        /// </summary>
        Task<Service> GetMostPopularServiceAsync();
    }
}
