using AutoMapper;
using Business.Implements;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.NotificationDTO;
using Gym;
using Microsoft.Extensions.Logging;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class NotificationBusiness : BaseBusiness<Notification, NotificationDto>, INotificationBusiness
    {
        private readonly INotificationData _notificationData;
        private readonly IMembershipData _membershipData;

        public NotificationBusiness(
            INotificationData data,
            IMembershipData membershipData,
            IMapper mapper,
            ILogger<NotificationBusiness> logger,
            IGenericIHelpers helpers)
            : base(data, mapper, logger, helpers)
        {
            _notificationData = data;
            _membershipData = membershipData;
        }

        public async Task<IEnumerable<NotificationDto>> GetByUserIdAsync(int userId)
        {
            try
            {
                var notifications = await _notificationData.GetByUserIdAsync(userId);
                return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener notificaciones del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<NotificationDto>> GetByTypeAsync(string type)
        {
            try
            {
                var notifications = await _notificationData.GetByTypeAsync(type);
                return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener notificaciones de tipo {type}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<NotificationDto>> GetRecentNotificationsAsync(int userId, int count)
        {
            try
            {
                var notifications = await _notificationData.GetRecentNotificationsAsync(userId, count);
                return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener notificaciones recientes del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        public async Task SendExpirationNotificationsAsync()
        {
            try
            {
                var expiringMemberships = await _membershipData.GetExpiredMembershipsAsync();

                foreach (var membership in expiringMemberships)
                {
                    var notification = new Notification
                    {
                        UserId = membership.UserId,
                        Type = "expiration",
                        Message = $"Su membresía {membership.Type} ha expirado el {membership.EndDate:dd/MM/yyyy}",
                        SentDate = DateTime.UtcNow,
                        Status = true,
                        CreatedAt = DateTime.UtcNow
                    };

                    await _notificationData.CreateAsync(notification);
                }

                _logger.LogInformation("Notificaciones de expiración enviadas correctamente");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al enviar notificaciones de expiración: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Envía una notificación a un usuario específico
        /// </summary>
        /// <param name="userId">ID del usuario destinatario</param>
        /// <param name="type">Tipo de notificación</param>
        /// <param name="message">Mensaje de la notificación</param>
        /// <returns>La notificación creada</returns>
        public async Task<NotificationDto> SendNotificationAsync(int userId, string type, string message)
        {
            try
            {
                var notification = await _notificationData.SendNotificationAsync(userId, type, message);
                return _mapper.Map<NotificationDto>(notification);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al enviar notificación al usuario {userId}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Marca una notificación como leída
        /// </summary>
        /// <param name="notificationId">ID de la notificación a marcar como leída</param>
        /// <returns>True si se marcó correctamente, false en caso contrario</returns>
        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            try
            {
                return await _notificationData.MarkAsReadAsync(notificationId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al marcar notificación {notificationId} como leída: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene las notificaciones no leídas de un usuario
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        /// <returns>Lista de notificaciones no leídas</returns>
        public async Task<IEnumerable<NotificationDto>> GetUnreadNotificationsAsync(int userId)
        {
            try
            {
                var notifications = await _notificationData.GetUnreadNotificationsAsync(userId);
                return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener notificaciones no leídas del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Elimina notificaciones antiguas del sistema
        /// </summary>
        /// <param name="daysOld">Número de días de antigüedad para considerar una notificación como antigua</param>
        /// <returns>Número de notificaciones eliminadas</returns>
        public async Task<int> DeleteOldNotificationsAsync(int daysOld)
        {
            try
            {
                return await _notificationData.DeleteOldNotificationsAsync(daysOld);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar notificaciones antiguas ({daysOld} días): {ex.Message}");
                throw;
            }
        }
    }
}
