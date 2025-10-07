using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Gym;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements.NotificationData
{
    public class NotificationData : BaseModelData<Notification>, INotificationData
    {
        public NotificationData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(n => n.UserId == userId && n.Status)
                .OrderByDescending(n => n.SentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetByTypeAsync(string type)
        {
            return await _dbSet
                .Where(n => n.Type == type && n.Status)
                .Include(n => n.User)
                .OrderByDescending(n => n.SentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetRecentNotificationsAsync(int userId, int count)
        {
            return await _dbSet
                .Where(n => n.UserId == userId && n.Status)
                .OrderByDescending(n => n.SentDate)
                .Take(count)
                .ToListAsync();
        }

        /// <summary>
        /// Envía una notificación a un usuario específico
        /// </summary>
        /// <param name="userId">ID del usuario destinatario</param>
        /// <param name="type">Tipo de notificación</param>
        /// <param name="message">Mensaje de la notificación</param>
        /// <returns>La notificación creada</returns>
        public async Task<Notification> SendNotificationAsync(int userId, string type, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Type = type,
                Message = message,
                SentDate = DateTime.UtcNow,
                IsRead = false,
                Status = true,
                CreatedAt = DateTime.UtcNow
            };

            return await CreateAsync(notification);
        }

        /// <summary>
        /// Marca una notificación como leída
        /// </summary>
        /// <param name="notificationId">ID de la notificación</param>
        /// <returns>True si se marcó correctamente, false en caso contrario</returns>
        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            var notification = await _dbSet
                .FirstOrDefaultAsync(n => n.Id == notificationId && n.Status);

            if (notification == null)
                return false;

            notification.IsRead = true;
            notification.UpdatedAt = DateTime.UtcNow;
            await UpdateAsync(notification);

            return true;
        }

        /// <summary>
        /// Obtiene todas las notificaciones no leídas de un usuario
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        /// <returns>Lista de notificaciones no leídas</returns>
        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(int userId)
        {
            return await _dbSet
                .Where(n => n.UserId == userId && !n.IsRead && n.Status)
                .Include(n => n.User)
                .OrderByDescending(n => n.SentDate)
                .ToListAsync();
        }

        /// <summary>
        /// Elimina notificaciones antiguas basadas en días de antigüedad
        /// </summary>
        /// <param name="daysOld">Número de días de antigüedad</param>
        /// <returns>Número de notificaciones eliminadas</returns>
        public async Task<int> DeleteOldNotificationsAsync(int daysOld)
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-daysOld);

            var oldNotifications = await _dbSet
                .Where(n => n.SentDate < cutoffDate)
                .ToListAsync();

            foreach (var notification in oldNotifications)
            {
                notification.Status = false;
                notification.DeleteAt = DateTime.UtcNow;
                await UpdateAsync(notification);
            }

            return oldNotifications.Count;
        }
    }
}
