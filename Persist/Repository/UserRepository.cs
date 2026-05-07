using Microsoft.EntityFrameworkCore;

using Persist;
using Persist.Entities.Auth;

namespace Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateUser(UserEntity user)
        {

        }

        public async Task<UserEntity?> GetUserByEmail(string email)
        {
            return await _context.User
                .Include(u => u.HashPasswordEntity)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity?> GetUserByToken(string token)
        {
            return await _context.User
                .Include(u => u.RefreshToken)
                .FirstOrDefaultAsync(u =>
                    u.RefreshToken != null &&
                    u.RefreshToken.RefreshToken == token);
        }

        public async Task<bool> IsUserExist(string email)
        {
            return await _context.User.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsUserEmailConfirmed(string email)
        {
            return await _context.User.AnyAsync(u =>
                u.Email == email && u.IsEmailConfirmed);
        }

        Task<bool> IUserRepository.CreateUser(UserEntity user)
        {
            _context.User.Add(user);
            _context.SaveChangesAsync();
            return Task.FromResult(true);
        }
    }
}