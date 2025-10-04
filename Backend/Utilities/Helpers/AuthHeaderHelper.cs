using Microsoft.AspNetCore.Http;
using Utilities.Interfaces;

namespace Utilities.Helpers
{
    /// <summary>
    /// Da funciones para extraer y procesar encabezados de autenticación de solicitudes HTTP.
    /// </summary>
    public class AuthHeaderHelper : IAuthHeaderHelper
    {
        /// <summary>
        /// Extrae el token Bearer del encabezado de autorización de una solicitud HTTP.
        /// </summary>
        /// <param name="request">La solicitud HTTP de la cual extraer el token.</param>
        /// <returns>El token Bearer si existe; de lo contrario, null.</returns>
        /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro request es null.</exception>
        public string ExtractBearerToken(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string authHeader = request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                return null;

            return authHeader.Substring("Bearer ".Length).Trim();
        }

        /// <summary>
        /// Extrae el nombre de usuario y la contraseña de un encabezado de autenticación básica.
        /// </summary>
        /// <param name="request">La solicitud HTTP de la cual extraer las credenciales.</param>
        /// <returns>Una tupla que contiene el nombre de usuario y la contraseña. Ambos valores
        /// serán null si no se puede extraer la información.</returns>
        /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro request es null.</exception>
        public (string username, string password) ExtractBasicAuth(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string authHeader = request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                return (null, null);

            string encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
            byte[] decodedBytes = Convert.FromBase64String(encodedCredentials);
            string decodedCredentials = System.Text.Encoding.UTF8.GetString(decodedBytes);

            int colonIndex = decodedCredentials.IndexOf(':');
            if (colonIndex < 0)
                return (null, null);

            string username = decodedCredentials.Substring(0, colonIndex);
            string password = decodedCredentials.Substring(colonIndex + 1);

            return (username, password);
        }

        /// <summary>
        /// Intenta obtener el token Bearer de una solicitud HTTP.
        /// </summary>
        /// <param name="request">La solicitud HTTP de la cual extraer el token.</param>
        /// <param name="token">Cuando este método retorna, contiene el token Bearer
        /// extraído de la solicitud si la extracción fue exitosa; de lo contrario, null.</param>
        /// <returns>true si el token se extrajo exitosamente; de lo contrario, false.</returns>
        public bool TryGetBearerToken(HttpRequest request, out string token)
        {
            token = ExtractBearerToken(request);
            return !string.IsNullOrEmpty(token);
        }
    }
}