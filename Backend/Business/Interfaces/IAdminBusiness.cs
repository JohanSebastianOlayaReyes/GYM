using Entity.Dtos.AdminDTO;

namespace Business.Interfaces
{
    /// <summary>
    /// Interfaz para la lógica de negocio relacionada con administradores.
    /// </summary>
    public interface IAdminBusiness
    {
        /// <summary>
        /// Registra un nuevo administrador en el sistema.
        /// </summary>
        Task<AdminResponseDto> RegisterAsync(AdminRegisterDto registerDto);

        /// <summary>
        /// Autentica a un administrador y genera un token JWT.
        /// </summary>
        Task<AdminResponseDto> LoginAsync(AdminLoginDto loginDto);

        /// <summary>
        /// Verifica si existe un administrador con el email proporcionado.
        /// </summary>
        Task<bool> ExistsByEmailAsync(string email);
    }
}
