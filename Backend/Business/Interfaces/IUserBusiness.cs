using Business.Interfaces;
using Entity.Dtos.UserDTO;
using Entity.Model;

namespace Business.Interfaces
{
    ///<summary>
    /// Define los métodos de negocio específicos para la gestíon de usuarios.
    ///Hereda operaciones CRUD genéricas de <see cref="IBaseBusiness{User, UserDto}"/>.
    ///</summary>
    public interface IUserBusiness : IBaseBusiness<User, UserDto>
    {
        /// <summary>
        /// Obtiene un usuario por su dirección de correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario a buscar.</param>
        /// <returns>
        /// El <see cref="User"/> que coincida con el correo proporcionado o <c>null</c> si no se encuentra.
        /// </returns>
        Task<User> GetByEmailAsync(string email);

        /// <summary>
        /// Valida las credenciales de un usuario comparando el correo y la contraseña.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="password">Contraseña en texto plano para validar.</param>
        ///<returns>True si las credenciales son válidas; de lo contario false</returns>
        Task<bool> ValidateCredentialsAsync(string email, string password);

        /// <summary>
        /// Actualiza parcialmente los datos de un usuario.
        /// </summary>
        /// <param name="dto">Objeto que contiene los datos parciales a actualizar del usuario.</param>
        ///<returns>True si la actualización fue exitosa; de lo contario false</returns>
        Task<bool> UpdateParcialUserAsync(UpdateUserDto dto);

        /// <summary>
        /// Cambia el estado activo/inactivo de un usuario.
        /// </summary>
        /// <param name="dto">Objeto que contiene el ID del usuario y el nuevo estado activo.</param>
        ///<returns>True si el cambio de estado fue exitoso; de lo contario false</returns>

        Task<bool> SetUserActiveAsync(DeleteLogicalUserDto dto);


        ///<summary>
        /// Autentica un usuario en el sistema usando su corre electrónico y contraseña.
        //</summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Objeto <see cref="User"/> si las credenciales son válidas; de lo contrario, null.</returns>
        Task<User> LoginAsync(string email, string password);

        ///<summary>
        /// Cambia la contraseña de un usuario existente
        ///</summary>
        /// <param name="dto">Objeto que contiene el ID del usuario, la contraseña actual y la nueva contraseña.</param>
        /// <returns> True si la contraseña se cambió correctamente; false si el usuario no existe o la contraseña actual no coincide.</returns>
        Task<bool> ChangePasswordAsync(UpdatePasswordUserDto dto);

        ///<summary>
        /// Asigna un rol a un usuario específico.
        ///</summary>
        /// <param name="dto">Objeto que contiene el ID del usuario y el ID del rol a asignar.</param>
        /// <returns> True si el rol fue asignado correctamente; false si el usuario o el rol no existen. </returns>
        Task<bool> AssignRolAsync(AssignUserRolDto dto);

        /// <summary>
        /// Notifica al usuario mediante correo electrónico sobre la creación de su cuenta.
        /// </summary>
        /// <param name="emailDestino">Dirección de correo electrónico del destinatario.</param>
        /// <param name="nombre">Nombre del usuario para personalizar el mensaje.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        Task NotificarUsuarioAsync(string emailDestino, string nombre);

        /// <summary>
        /// Envía un correo electrónico con un enlace para restablecer la contraseña del usuario.
        /// </summary>
        /// <param name="email">Dirección de correo electrónico del usuario que solicita recuperar su contraseña.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        Task EnviarCorreoRecuperacionAsync(string email);


    }
}
    