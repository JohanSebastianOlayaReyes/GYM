namespace Entity.Dtos.AdminDTO
{
    /// <summary>
    /// DTO de respuesta con la información del administrador autenticado.
    /// </summary>
    public class AdminResponseDto
    {
        /// <summary>
        /// ID del administrador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del administrador.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Correo electrónico del administrador.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Nombre del gimnasio.
        /// </summary>
        public string GymName { get; set; }

        /// <summary>
        /// Token JWT de autenticación.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Fecha de expiración del token.
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}
