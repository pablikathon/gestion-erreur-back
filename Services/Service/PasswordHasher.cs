using System.Security.Cryptography;
namespace Services.Models.Auth{
    public  class PasswordHasher : IPasswordServiceHasher {
        private const int SaltSize = 16;
        private const int HasSize = 32;
        private const int Iteration = 1000;

        private static readonly HashAlgorithmName  Algorithm = HashAlgorithmName.SHA512;

        public string Hash(string password){
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password,salt,Iteration,Algorithm,HasSize);
            return  $"{Convert.ToHexString(hash)}- {Convert.ToHexString(salt)}";
        }

        public bool Validate(string passwordToCheck, string password)
        {
            string[] parts = passwordToCheck.Split("-");
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt,Iteration,Algorithm,HasSize);
            return hash.SequenceEqual(inputHash);
        }
    }
}