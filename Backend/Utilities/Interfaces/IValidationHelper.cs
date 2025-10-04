using System;
using FluentValidation;
using FluentValidation.Results;

namespace Utilities.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones de validación generales
    /// </summary>
    public interface IValidationHelper
    {
        /// <summary>
        /// Verifica si un número de teléfono es válido
        /// </summary>
        /// <param name="phoneNumber">El número de teléfono a validar</param>
        /// <returns>True si es válido, False en caso contrario</returns>
        bool IsValidPhoneNumber(string phoneNumber);

        /// <summary>
        /// Verifica si una contraseña es fuerte (contiene mayúsculas, minúsculas, números y caracteres especiales)
        /// </summary>
        /// <param name="password">La contraseña a validar</param>
        /// <returns>True si es fuerte, False en caso contrario</returns>
        bool IsStrongPassword(string password);

        /// <summary>
        /// Verifica si una URL es válida
        /// </summary>
        /// <param name="url">La URL a validar</param>
        /// <returns>True si es válida, False en caso contrario</returns>
        bool IsValidUrl(string url);

        /// <summary>
        /// Verifica si una dirección IP es válida (IPv4 o IPv6)
        /// </summary>
        /// <param name="ipAddress">La dirección IP a validar</param>
        /// <returns>True si es válida, False en caso contrario</returns>
        bool IsValidIp(string ipAddress);

        /// <summary>
        /// Verifica si un número de tarjeta de crédito es válido
        /// </summary>
        /// <param name="cardNumber">El número de tarjeta a validar</param>
        /// <returns>True si es válido, False en caso contrario</returns>
        bool IsValidCreditCard(string cardNumber);

        /// <summary>   
        /// Verifica si un número de identificación es válido
        /// </summary>
        /// <param name="identityNumber">El número de identificación a validar</param>
        /// <returns>True si es válido, False en caso contrario</returns>
        bool IsValidIdentityNumber(string identityNumber);


        Task<ValidationResult> Validate<T>(T dto);


    }
}