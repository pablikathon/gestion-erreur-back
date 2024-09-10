using Persist;
using Persist.Entities;

namespace Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTokenToUser(UserEntity user, RefreshTokenEntity refreshToken)
        {
            try
            {
                _context.RefreshToken.Add(refreshToken);
                if (user.RefreshToken != null)
                {
                    user.OldRefreshTokens.Add(user.RefreshToken);
                }
                user.RefreshToken = refreshToken;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task<bool> RenewPassword(UserEntity user, HashPasswordEntity hashPasswordEntity)
        {
            try
            {
                _context.HashPassword.Add(hashPasswordEntity);
                user.OldppHashPasswords.Add(user.HashPasswordEntity);
                user.HashPasswordEntity = hashPasswordEntity;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> Signup(UserEntity user)
        {
            try
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}