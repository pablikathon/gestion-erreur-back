using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Services.Models.Auth
{
    public class SecurityService : ISecurityService
    {
        private const int SaltSize = 16;
        private const int HasSize = 32;
        private const int Iteration = 10000;
        private readonly string Key ;


        private readonly HashAlgorithmName Algorithm;
        public SecurityService()
        {
            this.Algorithm = HashAlgorithmName.SHA512;
            this.Key = "ayuidajhkcxewbyryebbbefgrkdwdzwyhhammygfgisnnweocdskgvgikvmtqpccmjihjggvdkrvcugqelerpfglbqypgfunddgggrhcpdbaiwopcpftgjfiopgxruas";
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
        public string GenerateAccessToken(string Email)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(this.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

    }
}