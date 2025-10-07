using Entity.Model;
using Data.Interfaces;

namespace Data.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones de datos relacionadas con administradores.
    /// </summary>
    public interface IAdminData : IBaseModelData<Admin>
    {
        /// <summary>
        /// Autentica a un administrador con email y contraseña.
        /// </summary>
        Task<Admin> LoginAsync(string email, string password);

        /// <summary>
        /// Obtiene un administrador por su correo electrónico.
        /// </summary>
        Task<Admin> GetByEmailAsync(string email);

        /// <summary>
        /// Verifica si existe un administrador con el email proporcionado.
        /// </summary>
        Task<bool> ExistsByEmailAsync(string email);
    }
}
