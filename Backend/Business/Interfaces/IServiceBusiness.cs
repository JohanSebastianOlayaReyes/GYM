using Business.Interfaces;
using Entity.Dtos.ServiceDTO;
using Gym;

namespace Business.Interfaces
{
    public interface IServiceBusiness : IBaseBusiness<Service, ServiceDTO>
    {
        Task<IEnumerable<ServiceDTO>> GetActiveServicesAsync();
        Task<IEnumerable<ServiceDTO>> GetSubscriptionServicesAsync();

        /// <summary>
        /// Obtiene un servicio por su nombre
        /// </summary>
        /// <param name="name">Nombre del servicio a buscar</param>
        /// <returns>El servicio encontrado o null si no existe</returns>
        Task<ServiceDTO> GetByNameAsync(string name);

        /// <summary>
        /// Obtiene servicios dentro de un rango de precios
        /// </summary>
        /// <param name="minPrice">Precio mínimo</param>
        /// <param name="maxPrice">Precio máximo</param>
        /// <returns>Lista de servicios dentro del rango de precio especificado</returns>
        Task<IEnumerable<ServiceDTO>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);

        /// <summary>
        /// Obtiene el servicio más popular basado en el número de membresías
        /// </summary>
        /// <returns>El servicio más popular o null si no hay servicios</returns>
        Task<ServiceDTO> GetMostPopularServiceAsync();
    }
}
