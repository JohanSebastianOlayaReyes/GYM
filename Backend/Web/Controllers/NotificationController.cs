using Business.Interfaces;
using Entity.Dtos.NotificationDTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de notificaciones del sistema.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationBusiness _notificationBusiness;

        public NotificationController(INotificationBusiness notificationBusiness)
        {
            _notificationBusiness = notificationBusiness;
        }

        /// <summary>
        /// Obtiene todas las notificaciones del sistema.
        /// </summary>
        /// <returns>Lista de notificaciones.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var notifications = await _notificationBusiness.GetAllAsync();
                return Ok(new { success = true, data = notifications });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene una notificación por su ID.
        /// </summary>
        /// <param name="id">ID de la notificación.</param>
        /// <returns>Datos de la notificación.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var notification = await _notificationBusiness.GetByIdAsync(id);
                if (notification == null)
                    return NotFound(new { success = false, message = "Notificación no encontrada" });

                return Ok(new { success = true, data = notification });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las notificaciones de un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Lista de notificaciones del usuario.</returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var notifications = await _notificationBusiness.GetByUserIdAsync(userId);
                return Ok(new { success = true, data = notifications });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las notificaciones no leídas de un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Lista de notificaciones no leídas.</returns>
        [HttpGet("user/{userId}/unread")]
        public async Task<IActionResult> GetUnreadByUserId(int userId)
        {
            try
            {
                var notifications = await _notificationBusiness.GetUnreadNotificationsAsync(userId);
                return Ok(new { success = true, data = notifications });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las notificaciones recientes de un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <param name="count">Cantidad de notificaciones a obtener.</param>
        /// <returns>Lista de notificaciones recientes.</returns>
        [HttpGet("user/{userId}/recent")]
        public async Task<IActionResult> GetRecent(int userId, [FromQuery] int count = 10)
        {
            try
            {
                var notifications = await _notificationBusiness.GetRecentNotificationsAsync(userId, count);
                return Ok(new { success = true, data = notifications });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nueva notificación.
        /// </summary>
        /// <param name="notificationDto">Datos de la notificación a crear.</param>
        /// <returns>Notificación creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotificationDto notificationDto)
        {
            try
            {
                var createdNotification = await _notificationBusiness.CreateAsync(notificationDto);
                return CreatedAtAction(nameof(GetById), new { id = createdNotification.Id },
                    new { success = true, data = createdNotification, message = "Notificación creada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Envía una notificación a un usuario.
        /// </summary>
        /// <param name="userId">ID del usuario destinatario.</param>
        /// <param name="type">Tipo de notificación.</param>
        /// <param name="message">Mensaje de la notificación.</param>
        /// <returns>Notificación enviada.</returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromQuery] int userId, [FromQuery] string type, [FromQuery] string message)
        {
            try
            {
                var notification = await _notificationBusiness.SendNotificationAsync(userId, type, message);
                return Ok(new { success = true, data = notification, message = "Notificación enviada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Marca una notificación como leída.
        /// </summary>
        /// <param name="id">ID de la notificación.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPatch("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            try
            {
                var result = await _notificationBusiness.MarkAsReadAsync(id);

                if (result)
                    return Ok(new { success = true, message = "Notificación marcada como leída" });

                return BadRequest(new { success = false, message = "No se pudo marcar la notificación como leída" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza una notificación existente.
        /// </summary>
        /// <param name="id">ID de la notificación a actualizar.</param>
        /// <param name="notificationDto">Datos actualizados de la notificación.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotificationDto notificationDto)
        {
            try
            {
                notificationDto.Id = id;
                var result = await _notificationBusiness.UpdateAsync(notificationDto);

                if (result != null)
                    return Ok(new { success = true, message = "Notificación actualizada exitosamente", data = result });

                return BadRequest(new { success = false, message = "No se pudo actualizar la notificación" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una notificación.
        /// </summary>
        /// <param name="id">ID de la notificación a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _notificationBusiness.DeleteAsync(id);

                if (result)
                    return Ok(new { success = true, message = "Notificación eliminada exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar la notificación" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina notificaciones antiguas del sistema.
        /// </summary>
        /// <param name="daysOld">Número de días de antigüedad.</param>
        /// <returns>Cantidad de notificaciones eliminadas.</returns>
        [HttpDelete("old/{daysOld}")]
        public async Task<IActionResult> DeleteOld(int daysOld)
        {
            try
            {
                var count = await _notificationBusiness.DeleteOldNotificationsAsync(daysOld);
                return Ok(new { success = true, data = count, message = $"{count} notificaciones eliminadas" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
