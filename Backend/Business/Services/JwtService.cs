// Business/Services/JwtService.cs
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Entity.Dtos.AuthDTO;
using Entity.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Utilities.Interfaces;

namespace Business.Services
{
    /// <summary>
    /// Implementación del servicio JWT para la capa de negocio.
    /// </summary>
    public class JwtService : IJwtService
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor del servicio JWT.
        /// </summary>
        /// <param name="jwtGenerator">Generador de tokens de la capa de utilidades</param>
        /// <param name="configuration">Configuración de la aplicación</param>
        public JwtService(IJwtGenerator jwtGenerator, IConfiguration configuration)
        {
            _jwtGenerator = jwtGenerator;
            _configuration = configuration;
        }

        /// <summary>
        /// Genera un token JWT delegando a la capa de utilidades.
        /// </summary>
        /// <param name="user">Usuario para el cual generar el token</param>
        /// <returns>DTO con el token y su fecha de expiración</returns>
        public async Task<AuthDto> GenerateTokenAsync(User user)
        {
            // Delegamos la generación a la capa de utilidades
            return await _jwtGenerator.GeneradorToken(user);
        }

        /// <summary>
        /// Valida un token JWT y extrae sus claims.
        /// </summary>
        /// <param name="token">Token JWT a validar</param>
        /// <returns>ClaimsPrincipal con la información del token, o null si es inválido</returns>
        public ClaimsPrincipal ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:key"]);

            try
            {
                // Configurar los parámetros de validación
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                // Validar el token y obtener los claims
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                // Verificar que el tipo de token es JWT
                if (!(validatedToken is JwtSecurityToken jwtToken) ||
                    !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                // Si hay alguna excepción durante la validación, consideramos el token inválido
                return null;
            }
        }

        /// <summary>
        /// Verifica si un token es válido sin extraer sus claims.
        /// </summary>
        /// <param name="token">Token JWT a verificar</param>
        /// <returns>True si el token es válido; false en caso contrario</returns>
        public bool IsTokenValid(string token)
        {
            return ValidateToken(token) != null;
        }
    }
}