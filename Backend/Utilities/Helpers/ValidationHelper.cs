using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Utilities.Interfaces;

namespace Utilities.Helpers
{
    /// <summary>
    /// Implementación de la interfaz IValidationHelper que proporciona funcionalidades
    /// para la validación de diferentes tipos de datos como números telefónicos,
    /// contraseñas, URLs, direcciones IP, tarjetas de crédito y documentos de identidad.
    /// </summary>
    public class ValidationHelper : IValidationHelper
    {
        private readonly IValidatorFactory _validatorFactory;

        /// <summary>
        /// Constructor que inicializa una nueva instancia de ValidationHelper
        /// </summary>
        /// <param name="validatorFactory">Factory para obtener validadores de FluentValidation</param>
        public ValidationHelper(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory ?? throw new ArgumentNullException(nameof(validatorFactory));
        }

        /// <summary>
        /// Verifica si un número de teléfono tiene un formato válido.
        /// </summary>
        /// <param name="phoneNumber">El número de teléfono a validar.</param>
        /// <returns>
        /// True si el número de teléfono tiene un formato válido;
        /// False si es nulo, vacío o no cumple con el formato esperado.
        /// </returns>
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            var normalizedPhone = Regex.Replace(phoneNumber, @"[\s\-\(\)]", string.Empty);

            var regex = new Regex(@"^\+?[0-9]{8,15}$");
            return regex.IsMatch(normalizedPhone);
        }

        /// <summary>
        /// Verifica si una contraseña cumple con los criterios de seguridad establecidos.
        /// </summary>
        /// <param name="password">La contraseña a validar.</param>
        /// <returns>
        /// True si la contraseña es considerada fuerte;
        /// False si es nula, vacía o no cumple con los requisitos de seguridad.
        /// </returns>
        public bool IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasUppercase = password.Any(char.IsUpper);
            bool hasLowercase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(c => !char.IsLetterOrDigit(c));

            return hasUppercase && hasLowercase && hasDigit && hasSpecialChar;
        }

        /// <summary>
        /// Verifica si una URL tiene un formato válido y utiliza el protocolo HTTP o HTTPS.
        /// </summary>
        /// <param name="url">La URL a validar.</param>
        /// <returns>
        /// True si la URL tiene un formato válido y usa un protocolo soportado;
        /// False si es nula, vacía o no cumple con los requisitos.
        /// </returns>
        public bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// Verifica si una cadena representa una dirección IP válida (IPv4 o IPv6).
        /// </summary>
        /// <param name="ipAddress">La dirección IP a validar.</param>
        /// <returns>
        /// True si la cadena representa una dirección IP válida;
        /// False si es nula, vacía o no tiene un formato correcto de IPv4 o IPv6.
        /// </returns>
        public bool IsValidIp(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
                return false;

            var ipv4Regex = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}" +
                                      @"(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

            if (ipv4Regex.IsMatch(ipAddress))
                return true;

            var ipv6Regex = new Regex(@"^([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}$" +
                                      @"|([0-9a-fA-F]{1,4}:){1,7}:$" +
                                      @"|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}$" +
                                      @"|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}$" +
                                      @"|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}$" +
                                      @"|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}$" +
                                      @"|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}$" +
                                      @"|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})$" +
                                      @"|:((:[0-9a-fA-F]{1,4}){1,7}|:)$");

            return ipv6Regex.IsMatch(ipAddress);
        }

        /// <summary>
        /// Verifica si un número de tarjeta de crédito es válido utilizando el algoritmo de Luhn.
        /// </summary>
        /// <param name="cardNumber">El número de tarjeta de crédito a validar.</param>
        /// <returns>
        /// True si el número de tarjeta de crédito es válido según el algoritmo de Luhn;
        /// False si es nulo, vacío o no pasa la validación.
        /// </returns>
        public bool IsValidCreditCard(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            var normalizedCard = Regex.Replace(cardNumber, @"[\s\-]", string.Empty);

            if (!normalizedCard.All(char.IsDigit))
                return false;

            int sum = 0;
            bool alternate = false;
            for (int i = normalizedCard.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(normalizedCard[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                        n = (n % 10) + 1;
                }
                sum += n;
                alternate = !alternate;
            }

            return (sum % 10 == 0);
        }

        /// <summary>
        /// Verifica si un número de identificación personal tiene un formato válido.
        /// </summary>
        /// <param name="identityNumber">El número de identificación a validar.</param>
        /// <returns>
        /// True si el número de identificación tiene un formato potencialmente válido;
        /// False si es nulo, vacío o no cumple con los criterios básicos de validación.
        /// </returns>
        public bool IsValidIdentityNumber(string identityNumber)
        {
            if (string.IsNullOrWhiteSpace(identityNumber))
                return false;

            var normalizedId = Regex.Replace(identityNumber, @"[\s\-]", string.Empty);

            if (normalizedId.Length < 8 || normalizedId.Length > 15)
                return false;

            return normalizedId.All(c => char.IsLetterOrDigit(c));
        }

        /// <summary>
        /// Valida un objeto DTO utilizando los validadores configurados en FluentValidation.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a validar</typeparam>
        /// <param name="dto">Objeto a validar</param>
        /// <returns>Resultado de la validación</returns>
        public async Task<ValidationResult> Validate<T>(T dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var validator = _validatorFactory.GetValidator<T>();
            if (validator == null)
                return new ValidationResult(); // Devuelve un resultado vacío si no hay validador

            return await validator.ValidateAsync(dto);
        }
    }
}