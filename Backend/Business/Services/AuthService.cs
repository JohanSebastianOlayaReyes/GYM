using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Entity.Dtos.AuthDTO;
using Entity.Dtos.UserDTO;
using Microsoft.Extensions.Logging;

namespace Business.Services
{
    /// <summary>
    /// Implementaci�n del servicio de autenticaci�n que gestiona el proceso de login
    /// y obtenci�n de tokens JWT.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthService> _logger;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de autenticaci�n.
        /// </summary>
        /// <param name="userBusiness">Servicio para operaciones de negocio relacionadas con usuarios.</param>
        /// <param name="jwtService">Servicio para la generaci�n y validaci�n de tokens JWT.</param>
        /// <param name="logger">Servicio de logging para registrar eventos y errores.</param>
        public AuthService(
            IUserBusiness userBusiness,
            IJwtService jwtService,
            ILogger<AuthService> logger)
        {
            _userBusiness = userBusiness;
            _jwtService = jwtService;
            _logger = logger;
        }

        /// <summary>
        /// Autentica a un usuario utilizando sus credenciales y genera un token JWT.
        /// </summary>
        /// <param name="credenciales">Credenciales del usuario (email y contrase�a).</param>
        /// <returns>Un objeto AuthDto que contiene el token JWT y su fecha de expiraci�n.</returns>
        /// <exception cref="UnauthorizedAccessException">Se lanza cuando las credenciales proporcionadas son inv�lidas.</exception>
        /// <exception cref="Exception">Se lanza cuando ocurre un error inesperado durante el proceso de autenticaci�n.</exception>
        public async Task<AuthDto> LoginAsync(CredencialesDto credenciales)
        {
            try
            {
                // Verificar las credenciales del usuario
                var user = await _userBusiness.LoginAsync(credenciales.Email, credenciales.Password);

                // Si no se encontr� el usuario o las credenciales son incorrectas
                if (user == null)
                    throw new UnauthorizedAccessException("Credenciales inv�lidas");

                // Convertir User a UserDto para el JWT service
                var userDto = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email
                };

                // Generar y devolver el token JWT
                return await _jwtService.GenerateTokenAsync(userDto);
            }
            catch (Exception ex)
            {
                // Registrar el error para diagn�stico
                _logger.LogError($"Error durante el login: {ex.Message}");

                // Relanzar la excepci�n para que se maneje en capas superiores
                throw;
            }
        }
    }
}