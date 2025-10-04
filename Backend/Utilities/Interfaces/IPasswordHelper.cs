using System;

namespace Utilities.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones relacionadas con contraseñas
    /// </summary>
    public interface IPasswordHelper
    {
        /// <summary>
        /// Genera un hash seguro para una contraseña
        /// </summary>
        /// <param name="password">La contraseña a hashear</param>
        /// <returns>El hash de la contraseña</returns>
        string HashPassword(string password);

        /// <summary>
        /// Verifica si una contraseña coincide con su hash almacenado
        /// </summary>
        /// <param name="hashedPassword">El hash almacenado de la contraseña</param>
        /// <param name="providedPassword">La contraseña proporcionada para verificar</param>
        /// <returns>True si la contraseña coincide, False en caso contrario</returns>
        bool VerifyPassword(string hashedPassword, string providedPassword);

        /// <summary>
        /// Genera una contraseña aleatoria segura
        /// </summary>
        /// <param name="length">La longitud de la contraseña (predeterminada: 12)</param>
        /// <returns>Una contraseña aleatoria</returns>
        string GenerateRandomPassword(int length = 12);
    }
}