using System.Security.Cryptography;
namespace Services.Models.Auth{
    public  class PasswordHasherService : IPasswordHasherService {
        private const int SaltSize = 16;
        private const int HasSize = 32;
        private const int Iteration = 10000;

        private readonly HashAlgorithmName  Algorithm ;
        public PasswordHasherService() {
            this.Algorithm = HashAlgorithmName.SHA512;
        }
        public  string Hash(string password){
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password,salt,Iteration,Algorithm,HasSize);
            var result = $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
            return  result;
        }

        public bool Validate(string passwordToCheck, string password)
        {
            string[] parts = passwordToCheck.Split("-");
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt,Iteration,Algorithm,HasSize);
            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}