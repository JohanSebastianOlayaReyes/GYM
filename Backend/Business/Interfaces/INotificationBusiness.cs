using Business.Interfaces;
using Entity.Dtos.NotificationDTO;
using Gym;

namespace Business.Interfaces
{
    public interface INotificationBusiness : IBaseBusiness<Notification, NotificationDto>
    {
        Task<IEnumerable<NotificationDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<NotificationDto>> GetByTypeAsync(string type);
        Task<IEnumerable<NotificationDto>> GetRecentNotificationsAsync(int userId, int count);
        Task SendExpirationNotificationsAsync();

        /// <summary>
        /// Envía una notificación a un usuario específico
        /// </summary>
        /// <param name="userId">ID del usuario destinatario</param>
        /// <param name="type">Tipo de notificación</param>
        /// <param name="message">Mensaje de la notificación</param>
        /// <returns>La notificación creada</returns>
        Task<NotificationDto> SendNotificationAsync(int userId, string type, string message);

        /// <summary>
        /// Marca una notificación como leída
        /// </summary>
        /// <param name="notificationId">ID de la notificación a marcar como leída</param>
        /// <returns>True si se marcó correctamente, false en caso contrario</returns>
        Task<bool> MarkAsReadAsync(int notificationId);

        /// <summary>
        /// Obtiene las notificaciones no leídas de un usuario
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        /// <returns>Lista de notificaciones no leídas</returns>
        Task<IEnumerable<NotificationDto>> GetUnreadNotificationsAsync(int userId);

        /// <summary>
        /// Elimina notificaciones antiguas del sistema
        /// </summary>
        /// <param name="daysOld">Número de días de antigüedad para considerar una notificación como antigua</param>
        /// <returns>Número de notificaciones eliminadas</returns>
        Task<int> DeleteOldNotificationsAsync(int daysOld);
    }
}
