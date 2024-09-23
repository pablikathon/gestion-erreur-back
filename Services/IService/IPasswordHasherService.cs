using Persist.Entities.Auth;
namespace Services
{
    public interface ISecurityService
    {
        public string Hash(string password);

        public bool Validate(string passwordToCheck, string password);
        public string GenerateAccessToken(UserEntity user);
        public string GenerateRefreshToken();


    }
}