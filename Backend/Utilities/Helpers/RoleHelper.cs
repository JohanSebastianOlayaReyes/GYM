using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Interfaces;

namespace Utilities.Helpers
{
    /// <summary>
    /// Implementación de la interfaz IRoleHelper que proporciona funcionalidades
    /// para la gestión y validación de roles y permisos de usuarios.
    /// </summary>
    public class RoleHelper : IRoleHelper
    {
        /// <summary>
        /// Verifica si un usuario con los roles especificados tiene un permiso determinado.
        /// </summary>
        /// <param name="userRole">Colección de roles que posee el usuario.</param>
        /// <param name="requiredPermission">El permiso requerido que se verificará.</param>
        /// <returns>
        /// True si el usuario tiene el permiso requerido o si posee el rol 'Admin';
        /// False si el usuario no tiene el permiso o si algún parámetro es nulo o vacío.
        /// </returns>
        public bool HasPermission(IEnumerable<string> userRole, string requiredPermission)
        {
            if (userRole == null || string.IsNullOrWhiteSpace(requiredPermission))
                return false;

            // Aquí podrías implementar una lógica más compleja de permisos
            // Este es un ejemplo simple donde asumimos que el admin tiene todos los permisos
            if (userRole.Contains("Admin", StringComparer.OrdinalIgnoreCase))
                return true;

            // Verificar si el usuario tiene el permiso específico
            return userRole.Contains(requiredPermission, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Verifica si un usuario posee un rol específico.
        /// </summary>
        /// <param name="userRole">Colección de roles que posee el usuario.</param>
        /// <param name="roleName">El nombre del rol a verificar.</param>
        /// <returns>
        /// True si el usuario tiene el rol especificado;
        /// False si el usuario no tiene el rol o si algún parámetro es nulo o vacío.
        /// </returns>
        public bool IsInRole(IEnumerable<string> userRole, string roleName)
        {
            if (userRole == null || string.IsNullOrWhiteSpace(roleName))
                return false;

            return userRole.Contains(roleName, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Verifica si un usuario posee al menos uno de los roles requeridos.
        /// </summary>
        /// <param name="userRole">Colección de roles que posee el usuario.</param>
        /// <param name="requiredRole">Colección de roles requeridos para la verificación.</param>
        /// <returns>
        /// True si el usuario tiene al menos uno de los roles requeridos;
        /// False si el usuario no tiene ninguno de los roles requeridos o si algún parámetro es nulo o vacío.
        /// </returns>
        public bool HasAnyRole(IEnumerable<string> userRole, IEnumerable<string> requiredRole)
        {
            if (userRole == null || requiredRole == null || !requiredRole.Any())
                return false;

            return userRole.Intersect(requiredRole, StringComparer.OrdinalIgnoreCase).Any();
        }

        /// <summary>
        /// Obtiene el rol de mayor prioridad que posee un usuario.
        /// </summary>
        /// <param name="userRole">Colección de roles que posee el usuario.</param>
        /// <param name="rolePriorities">Diccionario que asigna prioridades numéricas a los nombres de roles.</param>
        /// <returns>
        /// El nombre del rol con la mayor prioridad que posee el usuario;
        /// Null si el usuario no tiene roles, si no se proporcionan prioridades, o si ninguno de los roles
        /// del usuario está presente en el diccionario de prioridades.
        /// </returns>
        public string GetHighestRole(IEnumerable<string> userRole, IDictionary<string, int> rolePriorities)
        {
            if (userRole == null || !userRole.Any() || rolePriorities == null || !rolePriorities.Any())
                return null;

            int highestPriority = -1;
            string highestRole = null;

            foreach (var role in userRole)
            {
                if (rolePriorities.TryGetValue(role, out int priority) && priority > highestPriority)
                {
                    highestPriority = priority;
                    highestRole = role;
                }
            }

            return highestRole;
        }
    }
}