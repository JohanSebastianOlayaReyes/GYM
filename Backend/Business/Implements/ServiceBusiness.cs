using AutoMapper;
using Business.Implements;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.ServiceDTO;
using Gym;
using Microsoft.Extensions.Logging;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class ServiceBusiness : BaseBusiness<Service, ServiceDTO>, IServiceBusiness
    {
        private readonly IServiceData _serviceData;

        public ServiceBusiness(
            IServiceData data,
            IMapper mapper,
            ILogger<ServiceBusiness> logger,
            IGenericIHelpers helpers)
            : base(data, mapper, logger, helpers)
        {
            _serviceData = data;
        }

        public async Task<IEnumerable<ServiceDTO>> GetActiveServicesAsync()
        {
            try
            {
                var services = await _serviceData.GetActiveServicesAsync();
                return _mapper.Map<IEnumerable<ServiceDTO>>(services);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener servicios activos: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<ServiceDTO>> GetSubscriptionServicesAsync()
        {
            try
            {
                var services = await _serviceData.GetSubscriptionServicesAsync();
                return _mapper.Map<IEnumerable<ServiceDTO>>(services);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener servicios de suscripción: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un servicio por su nombre
        /// </summary>
        /// <param name="name">Nombre del servicio a buscar</param>
        /// <returns>El servicio encontrado o null si no existe</returns>
        public async Task<ServiceDTO> GetByNameAsync(string name)
        {
            try
            {
                var service = await _serviceData.GetByNameAsync(name);
                return _mapper.Map<ServiceDTO>(service);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener servicio por nombre '{name}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene servicios dentro de un rango de precios
        /// </summary>
        /// <param name="minPrice">Precio mínimo</param>
        /// <param name="maxPrice">Precio máximo</param>
        /// <returns>Lista de servicios dentro del rango de precio especificado</returns>
        public async Task<IEnumerable<ServiceDTO>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var services = await _serviceData.GetByPriceRangeAsync(minPrice, maxPrice);
                return _mapper.Map<IEnumerable<ServiceDTO>>(services);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener servicios por rango de precio ({minPrice} - {maxPrice}): {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el servicio más popular basado en el número de membresías
        /// </summary>
        /// <returns>El servicio más popular o null si no hay servicios</returns>
        public async Task<ServiceDTO> GetMostPopularServiceAsync()
        {
            try
            {
                var service = await _serviceData.GetMostPopularServiceAsync();
                return _mapper.Map<ServiceDTO>(service);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener servicio más popular: {ex.Message}");
                throw;
            }
        }
    }
}
