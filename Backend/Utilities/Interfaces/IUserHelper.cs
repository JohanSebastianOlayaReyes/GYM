using System;
using Entity.Dtos.UserDTO;

namespace Utilities.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones relacionadas con usuarios
    /// </summary>
    public interface IUserHelper
    {
        /// <summary>
        /// Verifica si una dirección de correo electrónico es válida
        /// </summary>
        /// <param name="email">La dirección de correo electrónico a validar</param>
        /// <returns>True si es válida, False en caso contrario</returns>
        bool IsValidEmail(string email);

        /// <summary>
        /// Verifica si un nombre de usuario es válido
        /// </summary>
        /// <param name="username">El nombre de usuario a validar</param>
        /// <returns>True si es válido, False en caso contrario</returns>
        bool IsValidUsername(string username);

        /// <summary>
        /// Normaliza un nombre de usuario (elimina espacios, convierte a minúsculas, etc.)
        /// </summary>
        /// <param name="username">El nombre de usuario a normalizar</param>
        /// <returns>El nombre de usuario normalizado</returns>
        string NormalizeUsername(string username);

        /// <summary>
        /// Obtiene el nombre completo de un usuario
        /// </summary>
        /// <param name="user">El usuario</param>
        /// <returns>El nombre completo del usuario</returns>
       // string GetUserFullName(UserDto user);

        /// <summary>
        /// Obtiene las iniciales de un usuario
        /// </summary>
        /// <param name="user">El usuario</param>
        /// <returns>Las iniciales del usuario</returns>
    //    string GetUserInitials(UserDto user);
    }
}