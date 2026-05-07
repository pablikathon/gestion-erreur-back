using Persist.Entities.Auth;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(UserEntity user);
        Task<UserEntity?> GetUserByEmail(string email);
        Task<UserEntity?> GetUserByToken(string token);
        Task<bool> IsUserExist(string Email);
        Task<bool> IsUserEmailConfirmed(string Email);
    }
}