using System;
using System.Collections.Generic;

namespace Utilities.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones relacionadas con roles y permisos
    /// </summary>
    public interface IRoleHelper
    {
        /// <summary>
        /// Verifica si un usuario tiene un permiso específico
        /// </summary>
        /// <param name="userRole">Los roles del usuario</param>
        /// <param name="requiredPermission">El permiso requerido</param>
        /// <returns>True si el usuario tiene el permiso, False en caso contrario</returns>
        bool HasPermission(IEnumerable<string> userRole, string requiredPermission);

        /// <summary>
        /// Verifica si un usuario tiene un rol específico
        /// </summary>
        /// <param name="userRole">Los roles del usuario</param>
        /// <param name="roleName">El nombre del rol a verificar</param>
        /// <returns>True si el usuario tiene el rol, False en caso contrario</returns>
        bool IsInRole(IEnumerable<string> userRole, string roleName);

        /// <summary>
        /// Verifica si un usuario tiene al menos uno de los roles requeridos
        /// </summary>
        /// <param name="userRole">Los roles del usuario</param>
        /// <param name="requiredRole">Los roles requeridos</param>
        /// <returns>True si el usuario tiene al menos uno de los roles, False en caso contrario</returns>
        bool HasAnyRole(IEnumerable<string> userRole, IEnumerable<string> requiredRole);

        /// <summary>
        /// Obtiene el rol de mayor prioridad de un usuario
        /// </summary>
        /// <param name="userRole">Los roles del usuario</param>
        /// <param name="rolePriorities">Diccionario con las prioridades de los roles</param>
        /// <returns>El rol de mayor prioridad</returns>
        string GetHighestRole(IEnumerable<string> userRole, IDictionary<string, int> rolePriorities);
    }
}