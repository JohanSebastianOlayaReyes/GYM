using System.Threading.Tasks;
using Entity.Dtos.AuthDTO;
using Entity.Dtos.CredencialesDTO;

namespace Business.Interfaces
{
    /// <summary>
    /// Define los métodos y operaciones de autenticación disponibles en el sistema.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Autentica a un usuario utilizando sus credenciales y genera un token JWT.
        /// </summary>
        /// <param name="credenciales">Objeto que contiene el correo electrónico y la contraseña del usuario.</param>
        /// <returns>Un objeto AuthDto que contiene el token JWT y su fecha de expiración.</returns>
        Task<AuthDto> LoginAsync(CredencialesDto credenciales);
    }
}