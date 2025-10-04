using Microsoft.AspNetCore.Http;
using System;

namespace Utilities.Interfaces
{
    /// <summary>
    /// Interfaz para manejar la extracción de tokens de autenticación desde los encabezados HTTP
    /// </summary>
    public interface IAuthHeaderHelper
    {
        /// <summary>
        /// Extrae el token JWT de un encabezado de autorización Bearer
        /// </summary>
        /// <param name="request">La solicitud HTTP</param>
        /// <returns>El token extraído o null si no existe o no es válido</returns>
        string ExtractBearerToken(HttpRequest request);

        /// <summary>
        /// Extrae las credenciales de autenticación básica (usuario y contraseña)
        /// </summary>
        /// <param name="request">La solicitud HTTP</param>
        /// <returns>Una tupla con el nombre de usuario y la contraseña</returns>
        (string username, string password) ExtractBasicAuth(HttpRequest request);

        /// <summary>
        /// Intenta obtener el token Bearer y devuelve un valor que indica si se encontró
        /// </summary>
        /// <param name="request">La solicitud HTTP</param>
        /// <param name="token">El token extraído, si existe</param>
        /// <returns>True si se encontró un token válido, False en caso contrario</returns>
        bool TryGetBearerToken(HttpRequest request, out string token);
    }
}