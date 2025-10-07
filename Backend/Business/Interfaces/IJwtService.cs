using Entity.Dtos.AuthDTO;
using Entity.Dtos.UserDTO;

namespace Business.Interfaces
{
    /// <summary>
    /// Interface para el servicio de generación y validación de tokens JWT
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Genera un token JWT para un usuario autenticado
        /// </summary>
        /// <param name="user">Usuario para el cual se generará el token</param>
        /// <returns>AuthDto con el token y su fecha de expiración</returns>
        Task<AuthDto> GenerateTokenAsync(UserDto user);
    }
}
