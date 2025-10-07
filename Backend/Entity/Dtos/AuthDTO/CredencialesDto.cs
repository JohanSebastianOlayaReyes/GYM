namespace Entity.Dtos.AuthDTO
{
    /// <summary>
    /// DTO para las credenciales de autenticación del usuario
    /// </summary>
    public class CredencialesDto
    {
        /// <summary>
        /// Email del usuario
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; set; }
    }
}
