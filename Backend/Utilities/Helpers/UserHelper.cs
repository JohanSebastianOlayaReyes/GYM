using System;
using System.Text.RegularExpressions;
using Utilities.Interfaces;
using Entity.Dtos.UserDTO;

namespace Utilities.Helpers
{
    /// <summary>
    /// Implementación de la interfaz IUserHelper que proporciona funcionalidades
    /// para la gestión y validación de información de usuarios.
    /// </summary>
    public class UserHelper : IUserHelper
    {
        public string GetUserFullName(UserDto user)
        {
            throw new NotImplementedException();
        }

        public string GetUserInitials(UserDto user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica si una dirección de correo electrónico es válida utilizando una expresión regular.
        /// </summary>
        /// <param name="email">La dirección de correo electrónico a validar.</param>
        /// <returns>
        /// True si la dirección de correo electrónico tiene un formato válido;
        /// False si la dirección es nula, vacía o no cumple con el formato básico de email.
        /// </returns>
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Expresión regular simple para validar emails
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        /// <summary>
        /// Verifica si un nombre de usuario es válido según los criterios establecidos.
        /// Un nombre de usuario válido debe tener entre 3 y 20 caracteres y solo puede contener
        /// letras, números, guiones y guiones bajos.
        /// </summary>
        /// <param name="username">El nombre de usuario a validar.</param>
        /// <returns>
        /// True si el nombre de usuario cumple con los criterios de validación;
        /// False si el nombre de usuario es nulo, vacío o no cumple con el formato requerido.
        /// </returns>
        public bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            // Solo permitir letras, números, guiones y guiones bajos
            var regex = new Regex(@"^[a-zA-Z0-9_-]{3,20}$");
            return regex.IsMatch(username);
        }

        /// <summary>
        /// Normaliza un nombre de usuario convirtiéndolo a minúsculas y eliminando espacios en blanco.
        /// </summary>
        /// <param name="username">El nombre de usuario a normalizar.</param>
        /// <returns>
        /// El nombre de usuario normalizado, o una cadena vacía si el nombre de usuario proporcionado es nulo o vacío.
        /// </returns>
        public string NormalizeUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return string.Empty;

            // Convertir a minúsculas y eliminar espacios en blanco
            return username.ToLowerInvariant().Trim();
        }

        /// <summary>
        /// Obtiene el nombre completo de un usuario basado en su información personal.
        /// </summary>
        /// <param name="user">El objeto UserDto que contiene la información del usuario.</param>
        /// <returns>
        /// El nombre completo del usuario formado por su nombre y apellido. Si alguno de estos campos
        /// está vacío, devuelve solo el campo disponible. Si no hay información personal disponible,
        /// devuelve el nombre de usuario o "Anonymous User" como último recurso.
        /// </returns>
        /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro user es nulo.</exception>

        ////public string GetUserFullName(UserDto user)
        //{
        //    if (user == null)
        //        throw new ArgumentNullException(nameof(user));

        //    if (!string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName))
        //        return $"{user.FirstName} {user.LastName}";

        //    if (!string.IsNullOrWhiteSpace(user.FirstName))
        //        return user.FirstName;

        //    if (!string.IsNullOrWhiteSpace(user.LastName))
        //        return user.LastName;

        //    return user.Username ?? "Anonymous User";
        //}

        /// <summary>
        /// Obtiene las iniciales de un usuario basadas en su nombre y apellido.
        /// </summary>
        /// <param name="user">El objeto UserDto que contiene la información del usuario.</param>
        /// <returns>
        /// Las iniciales del usuario en mayúsculas. Si no se puede extraer iniciales del nombre y apellido,
        /// se intenta usar la primera letra del nombre de usuario. Si tampoco es posible,
        /// se devuelve "U" como valor predeterminado.
        /// </returns>
        /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro user es nulo.</exception>


        //public string GetUserInitials(UserDto user)
        //{
        //    if (user == null)
        //        throw new ArgumentNullException(nameof(user));

        //    string initials = string.Empty;

        //    if (!string.IsNullOrWhiteSpace(user.FirstName) && user.FirstName.Length > 0)
        //        initials += user.FirstName[0];

        //    if (!string.IsNullOrWhiteSpace(user.LastName) && user.LastName.Length > 0)
        //        initials += user.LastName[0];

        //    if (string.IsNullOrWhiteSpace(initials) && !string.IsNullOrWhiteSpace(user.Username) && user.Username.Length > 0)
        //        initials = user.Username[0].ToString().ToUpper();

        //    return string.IsNullOrWhiteSpace(initials) ? "U" : initials.ToUpper();
        //}
    }
}