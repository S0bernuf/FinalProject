using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FinalProject.BusinessLogic.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string user, int userId)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user),
            new Claim(ClaimTypes.NameIdentifier, userId.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetJwtSecretKey()));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                GetJwtIssuer(),
                GetJwtAudience(),
                claims,
                expires: DateTime.Now.AddSeconds(GetJwtExpirationSeconds()),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return StructuralComparisons.StructuralEqualityComparer.Equals(computedHash, storedHash);
        }

        public User CreateUser(string username, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            return new User
            {
                UserName = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private string GetJwtSecretKey() => _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt secret key is missing in configuration.");
        private string GetJwtIssuer() => _configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("Jwt issuer is missing in configuration.");
        private string GetJwtAudience() => _configuration["Jwt:Audience"] ?? throw new InvalidOperationException("Jwt audience is missing in configuration.");
        private int GetJwtExpirationSeconds() => int.Parse(_configuration["Jwt:TokenExpirationInSeconds"] ?? "300");
    }
}
