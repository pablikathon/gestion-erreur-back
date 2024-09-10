using System.Security.Cryptography;
namespace Services
{
    public interface IPasswordHasherService
    {
        public string Hash(string password);

        public bool Validate(string passwordToCheck,string password);

    }
}