using MimeKit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities.Mail
{
    /// <summary>
    /// Define las operaciones básicas para un servicio de envío de correos electrónicos.
    /// Esta interfaz permite la inyección de dependencias y el testing unitario
    /// de componentes que requieren enviar correos.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Envía un mensaje de correo electrónico previamente configurado.
        /// </summary>
        /// <param name="message">Mensaje MIME completo con todos los detalles del correo a enviar.</param>
        /// <param name="cancellationToken">Token para cancelar la operación asíncrona.</param>
        /// <returns>Una tarea que representa la operación asíncrona de envío.</returns>
        Task SendEmailAsync(MimeMessage message, CancellationToken cancellationToken = default);

        /// <summary>
        /// Envía un correo electrónico a un único destinatario.
        /// </summary>
        /// <param name="to">Dirección de correo electrónico del destinatario.</param>
        /// <param name="subject">Asunto del correo.</param>
        /// <param name="body">Contenido del correo.</param>
        /// <param name="isHtml">Indica si el contenido es HTML (true) o texto plano (false).</param>
        /// <returns>True si el envío fue exitoso, False en caso contrario.</returns>
        Task<bool> SendEmailAsync(string to, string subject, string body, bool isHtml = true);

        /// <summary>
        /// Envía un correo electrónico a múltiples destinatarios.
        /// </summary>
        /// <param name="to">Lista de direcciones de correo de los destinatarios.</param>
        /// <param name="subject">Asunto del correo.</param>
        /// <param name="body">Contenido del correo.</param>
        /// <param name="isHtml">Indica si el contenido es HTML (true) o texto plano (false).</param>
        /// <returns>True si el envío fue exitoso, False en caso contrario.</returns>
        Task<bool> SendEmailToManyAsync(List<string> to, string subject, string body, bool isHtml = true);

        /// <summary>
        /// Envía un correo electrónico con opciones de copia (CC) y copia oculta (BCC).
        /// </summary>
        /// <param name="to">Dirección de correo del destinatario principal.</param>
        /// <param name="subject">Asunto del correo.</param>
        /// <param name="body">Contenido del correo.</param>
        /// <param name="cc">Lista opcional de direcciones para copia carbón (CC).</param>
        /// <param name="bcc">Lista opcional de direcciones para copia carbón oculta (BCC).</param>
        /// <param name="isHtml">Indica si el contenido es HTML (true) o texto plano (false).</param>
        /// <returns>True si el envío fue exitoso, False en caso contrario.</returns>
        Task<bool> SendEmailWithCopyAsync(string to, string subject, string body,
            List<string> cc = null, List<string> bcc = null, bool isHtml = true);
    }
}