using System.Security.Cryptography;
namespace Services
{
    public interface ISecurityService
    {
        public string Hash(string password);

        public bool Validate(string passwordToCheck, string password);
        public string GenerateAccessToken(string Email);
        public string GenerateRefreshToken();


    }
}