using System.Security.Cryptography;
namespace Services
{
    public interface IPasswordServiceHasher
    {
        public string Hash(string password);

        public bool Validate(string passwordToCheck,string password);

    }
}