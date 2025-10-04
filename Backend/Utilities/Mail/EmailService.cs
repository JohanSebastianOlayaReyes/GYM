using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp; // Usando MailKit en lugar de System.Net.Mail por sus mejores capacidades
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient; // Alias para evitar conflictos con System.Net.Mail.SmtpClient
using Utilities.Interfaces;

namespace Utilities.Mail
{
    /// <summary>
    /// Servicio para el envío de correos electrónicos utilizando MailKit.
    /// Implementa la interfaz IEmailService para facilitar la inyección de dependencias.
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _settings;

        /// <summary>
        /// Constructor que inicializa el servicio con la configuración SMTP.
        /// </summary>
        /// <param name="settings">Configuración SMTP que puede actualizarse en tiempo de ejecución.</param>
        public EmailService(IOptionsMonitor<SmtpSettings> settings)
        {
            _settings = settings.CurrentValue;
        }

        /// <summary>
        /// Método principal para enviar un correo electrónico ya configurado.
        /// Se encarga de la conexión al servidor SMTP, autenticación y envío.
        /// </summary>
        /// <param name="message">Mensaje de correo ya configurado.</param>
        /// <param name="cancellationToken">Token para cancelar la operación asíncrona.</param>
        /// <returns>Tarea que representa la operación asíncrona.</returns>
        public async Task SendEmailAsync(MimeMessage message, CancellationToken cancellationToken = default)
        {
            using var client = new SmtpClient(); // Instancia del cliente SMTP de MailKit
            // Conectar al servidor SMTP con los parámetros configurados
            await client.ConnectAsync(_settings.Server, _settings.Port ?? 25, _settings.EnableSsl, cancellationToken);

            // Autenticar si se proporcionaron credenciales
            if (!string.IsNullOrEmpty(_settings.Username))
                await client.AuthenticateAsync(_settings.Username, _settings.Password, cancellationToken);

            // Enviar el mensaje
            await client.SendAsync(message, cancellationToken);
            // Desconectar del servidor correctamente
            await client.DisconnectAsync(true, cancellationToken);
        }

        /// <summary>
        /// Envía un correo electrónico a un único destinatario.
        /// </summary>
        /// <param name="to">Dirección de correo del destinatario.</param>
        /// <param name="subject">Asunto del correo.</param>
        /// <param name="body">Contenido del correo.</param>
        /// <param name="isHtml">Indica si el contenido es HTML (true) o texto plano (false).</param>
        /// <returns>True si el envío fue exitoso, False en caso contrario.</returns>
        public async Task<bool> SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            try
            {
                // Crear el mensaje con los datos proporcionados
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
                message.To.Add(MailboxAddress.Parse(to));
                message.Subject = subject;

                // Configurar el cuerpo del mensaje según el formato
                var bodyBuilder = new BodyBuilder();
                if (isHtml)
                    bodyBuilder.HtmlBody = body;
                else
                    bodyBuilder.TextBody = body;

                message.Body = bodyBuilder.ToMessageBody();

                // Enviar el mensaje utilizando el método principal
                await SendEmailAsync(message);
                return true;
            }
            catch (Exception)
            {
                // En caso de error, retornar falso sin propagar la excepción
                // Nota: En un entorno de producción, sería recomendable registrar el error
                return false;
            }
        }

        /// <summary>
        /// Envía un correo electrónico a múltiples destinatarios.
        /// </summary>
        /// <param name="to">Lista de direcciones de correo de los destinatarios.</param>
        /// <param name="subject">Asunto del correo.</param>
        /// <param name="body">Contenido del correo.</param>
        /// <param name="isHtml">Indica si el contenido es HTML (true) o texto plano (false).</param>
        /// <returns>True si el envío fue exitoso, False en caso contrario.</returns>
        public async Task<bool> SendEmailToManyAsync(List<string> to, string subject, string body, bool isHtml = true)
        {
            try
            {
                // Crear el mensaje con los datos proporcionados
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));

                // Agregar todos los destinatarios de la lista
                foreach (var recipient in to)
                {
                    message.To.Add(MailboxAddress.Parse(recipient));
                }

                message.Subject = subject;

                // Configurar el cuerpo del mensaje según el formato
                var bodyBuilder = new BodyBuilder();
                if (isHtml)
                    bodyBuilder.HtmlBody = body;
                else
                    bodyBuilder.TextBody = body;

                message.Body = bodyBuilder.ToMessageBody();

                // Enviar el mensaje utilizando el método principal
                await SendEmailAsync(message);
                return true;
            }
            catch (Exception)
            {
                // En caso de error, retornar falso sin propagar la excepción
                return false;
            }
        }

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
        public async Task<bool> SendEmailWithCopyAsync(string to, string subject, string body, List<string> cc = null, List<string> bcc = null, bool isHtml = true)
        {
            try
            {
                // Crear el mensaje con los datos proporcionados
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
                message.To.Add(MailboxAddress.Parse(to));

                // Agregar destinatarios en copia (CC) si existen
                if (cc != null && cc.Count > 0)
                {
                    foreach (var recipient in cc)
                    {
                        message.Cc.Add(MailboxAddress.Parse(recipient));
                    }
                }

                // Agregar destinatarios en copia oculta (BCC) si existen
                if (bcc != null && bcc.Count > 0)
                {
                    foreach (var recipient in bcc)
                    {
                        message.Bcc.Add(MailboxAddress.Parse(recipient));
                    }
                }

                message.Subject = subject;

                // Configurar el cuerpo del mensaje según el formato
                var bodyBuilder = new BodyBuilder();
                if (isHtml)
                    bodyBuilder.HtmlBody = body;
                else
                    bodyBuilder.TextBody = body;

                message.Body = bodyBuilder.ToMessageBody();

                // Enviar el mensaje utilizando el método principal
                await SendEmailAsync(message);
                return true;
            }
            catch (Exception)
            {
                // En caso de error, retornar falso sin propagar la excepción
                return false;
            }
        }
    }
}