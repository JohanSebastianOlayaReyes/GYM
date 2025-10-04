using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entity.Dtos.AuthDTO;
using Entity.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Utilities.Interfaces;

namespace Utilities.Jwt
{
    /// <summary>
    /// Clase encargada de generar tokens JWT para autenticación.
    /// </summary>
    public class GenerateTokenJwt : IJwtGenerator
    {
        private readonly IConfiguration _configuration;


        /// <summary>
        /// Constructor que inyecta la configuración del proyecto para acceder a clave del archivo appsettings.json.
        /// </summary>
        /// <param name="configuration">Instancia de IConfiguration.</param>
        public GenerateTokenJwt(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Genera un token JWT basado en la información del usuario.
        /// </summary>
        /// <param name="data">Instancia del modelo User con la información del usuario autenticado.</param>
        /// <returns>Un objeto AuthDto que contiene el token y la fecha de expiración.</returns>
        public async Task<AuthDto> GeneradorToken(User data)
        {



            // 1. Claims (datos incluidos en el token)
            // En este caso solo el ID del usuario para evitar exposición de datos sensibles
            var claims = new List<Claim>
            {
                new Claim("id", data.Id.ToString())
                // Puedes agregar más claims si es necesario, como roles, permisos, etc.
                // new Claim(ClaimTypes.Role, data.Role),
            };


            // 2. Firma del Token
            // Se obtiene la clave secreta desde appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]!));

            // Se define el algoritmo de firma (HMAC SHA-256)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);




            // 3. Definir la expiración del token
            // Aquí se configura una duración de 1 hora.
            var expiracion = DateTime.UtcNow.AddHours(1);



            // 4. Crear el Token JWT
            var tokenSeguridad = new JwtSecurityToken(
                issuer: null,               // Puede configurarse si se requiere
                audience: null,             // Puede configurarse si se requiere
                claims: claims,             // Los datos incluidos
                expires: expiracion,        // Fecha de expiración
                signingCredentials: creds   // Firma
            );



            // 5. Serializar el token
            var token = new JwtSecurityTokenHandler().WriteToken(tokenSeguridad);


            // 6. Retornar DTO con token y expiración
            return new AuthDto
            {
                Token = token,
                Expiracion = expiracion
            };
        }

        /// <summary>
        /// Genera un token JWT de recuperación de contraseña para un usuario específico.
        /// </summary>
        /// <param name="user">El usuario para el cual se generará el token.</param>
        /// <param name="minutosExpiracion">Tiempo en minutos para que el token expire (por defecto 15 minutos).</param>
        /// <returns>Token JWT como cadena de texto.</returns>
        public string GenerarTokenRecuperacion(User user, int minutosExpiracion = 15)
        {
            // Se definen los "claims", es decir, los datos que contendrá el token
            var claims = new List<Claim>
    {
        new Claim("id", user.Id.ToString()),          // ID del usuario
        new Claim("email", user.Email),               // Email del usuario
        new Claim("tipo", "recuperacion")             // Tipo de token: recuperación
    };

            // Se obtiene la clave secreta desde la configuración (appsettings.json u otro origen)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]!));

            // Se generan las credenciales para firmar el token usando HMAC-SHA256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Se calcula la fecha de expiración del token
            var expiracion = DateTime.UtcNow.AddMinutes(minutosExpiracion);

            // Se construye el token JWT con los parámetros establecidos
            var tokenSeguridad = new JwtSecurityToken(
                issuer: null,              // Emisor no especificado
                audience: null,            // Audiencia no especificada
                claims: claims,            // Datos del token
                expires: expiracion,       // Tiempo de expiración
                signingCredentials: creds  // Firma del token
            );

            // Se convierte el token a una cadena y se devuelve
            return new JwtSecurityTokenHandler().WriteToken(tokenSeguridad);
        }

        /// <summary>
        /// Valida un token JWT recibido y devuelve los claims si es válido.
        /// </summary>
        /// <param name="token">Token JWT a validar.</param>
        /// <returns>Objeto ClaimsPrincipal con los datos del token si es válido; null si es inválido.</returns>
        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Se obtiene la misma clave secreta usada para generar el token
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:key"]!);

            try
            {
                // Validación del token con los parámetros definidos
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,                         // Validar la firma del token
                    IssuerSigningKey = new SymmetricSecurityKey(key),        // Clave usada para validar
                    ValidateIssuer = false,                                  // No se valida el emisor
                    ValidateAudience = false,                                // No se valida la audiencia
                    ClockSkew = TimeSpan.Zero                                // No se permite margen de tiempo tras expiración
                }, out SecurityToken validatedToken);

                return principal; // Si es válido, se retorna el usuario con sus claims
            }
            catch
            {
                return null; // Si es inválido o ha expirado, se retorna null
            }
        }
    }
}
