using Persist.Entities.Auth;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(UserEntity user);
    }
}