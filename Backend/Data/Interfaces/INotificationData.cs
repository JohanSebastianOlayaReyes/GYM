using Gym;

namespace Data.Interfaces
{
    public interface INotificationData : IBaseModelData<Notification>
    {
        Task<IEnumerable<Notification>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Notification>> GetByTypeAsync(string type);
        Task<IEnumerable<Notification>> GetRecentNotificationsAsync(int userId, int count);

        /// <summary>
        /// Envía una notificación a un usuario específico
        /// </summary>
        /// <param name="userId">ID del usuario destinatario</param>
        /// <param name="type">Tipo de notificación</param>
        /// <param name="message">Mensaje de la notificación</param>
        /// <returns>La notificación creada</returns>
        Task<Notification> SendNotificationAsync(int userId, string type, string message);

        /// <summary>
        /// Marca una notificación como leída
        /// </summary>
        /// <param name="notificationId">ID de la notificación</param>
        /// <returns>True si se marcó correctamente, false en caso contrario</returns>
        Task<bool> MarkAsReadAsync(int notificationId);

        /// <summary>
        /// Obtiene todas las notificaciones no leídas de un usuario
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        /// <returns>Lista de notificaciones no leídas</returns>
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(int userId);

        /// <summary>
        /// Elimina notificaciones antiguas basadas en días de antigüedad
        /// </summary>
        /// <param name="daysOld">Número de días de antigüedad</param>
        /// <returns>Número de notificaciones eliminadas</returns>
        Task<int> DeleteOldNotificationsAsync(int daysOld);
    }
}
