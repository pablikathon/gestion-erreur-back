using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Persist.Entities.Auth;

namespace Services.Models.Auth
{
    public sealed class SecurityService : ISecurityService
    {
        private const int SaltSize = 16;
        private const int HasSize = 32;
        private const int Iteration = 10000;
        public required IConfiguration Configuration { get; set; }

        private readonly HashAlgorithmName Algorithm;
        public SecurityService(IConfiguration configuration)
        {
            this.Algorithm = HashAlgorithmName.SHA512;
            this.Configuration = configuration;
        }
        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteration, Algorithm, HasSize);
            var result = $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
            return result;
        }

        public bool Validate(string passwordToCheck, string password)
        {
            string[] parts = passwordToCheck.Split("-");
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteration, Algorithm, HasSize);
            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public string GenerateAccessToken(UserEntity user)
        {
            string secureString = Configuration["Jwt:secret"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureString));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (JwtRegisteredClaimNames.Sub,user.Id),
                    new (JwtRegisteredClaimNames.Email,user.Email),
                    new ("email_verified",user.IsEmailConfirmed.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(Configuration.GetValue<int>("Jwt:ExpirationMinutes")),
                SigningCredentials = credentials,
                Issuer = Configuration["Jwt:Issuer"],
                Audience = Configuration["Jwt:Audience"]
            };
            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);
            return token;
        }

    }
}