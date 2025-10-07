using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.AdminDTO;
using Entity.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Implements
{
    /// <summary>
    /// Implementación de la lógica de negocio para administradores.
    /// </summary>
    public class AdminBusiness : IAdminBusiness
    {
        private readonly IAdminData _adminData;
        private readonly IConfiguration _configuration;

        public AdminBusiness(IAdminData adminData, IConfiguration configuration)
        {
            _adminData = adminData;
            _configuration = configuration;
        }

        /// <summary>
        /// Registra un nuevo administrador en el sistema.
        /// </summary>
        public async Task<AdminResponseDto> RegisterAsync(AdminRegisterDto registerDto)
        {
            // Verificar si el email ya existe
            if (await _adminData.ExistsByEmailAsync(registerDto.Email))
            {
                throw new Exception("El correo electrónico ya está registrado");
            }

            // Hash de la contraseña (en producción usar BCrypt o similar)
            var passwordHash = HashPassword(registerDto.Password);

            var admin = new Admin
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                GymName = registerDto.GymName,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow,
                State = true
            };

            await _adminData.Save(admin);

            // Generar token
            var token = GenerateJwtToken(admin);

            return new AdminResponseDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                GymName = admin.GymName,
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(8)
            };
        }

        /// <summary>
        /// Autentica a un administrador y genera un token JWT.
        /// </summary>
        public async Task<AdminResponseDto> LoginAsync(AdminLoginDto loginDto)
        {
            var passwordHash = HashPassword(loginDto.Password);
            var admin = await _adminData.LoginAsync(loginDto.Email, passwordHash);

            if (admin == null)
            {
                throw new UnauthorizedAccessException("Credenciales inválidas");
            }

            var token = GenerateJwtToken(admin);

            return new AdminResponseDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                GymName = admin.GymName,
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(8)
            };
        }

        /// <summary>
        /// Verifica si existe un administrador con el email proporcionado.
        /// </summary>
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _adminData.ExistsByEmailAsync(email);
        }

        /// <summary>
        /// Hash simple de contraseña (en producción usar BCrypt.Net-Next).
        /// </summary>
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        /// <summary>
        /// Genera un token JWT para el administrador.
        /// </summary>
        private string GenerateJwtToken(Admin admin)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Name, admin.Name),
                new Claim(ClaimTypes.Email, admin.Email),
                new Claim("GymName", admin.GymName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "GymSecretKey123456789012345678901234567890"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ?? "GymAPI",
                audience: _configuration["Jwt:Audience"] ?? "GymClient",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
