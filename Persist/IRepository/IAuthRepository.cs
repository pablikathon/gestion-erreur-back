using Persist.Entities;

namespace Repositories
{
    public interface IAuthRepository
    {
        Task <bool> Signup(UserEntity user);
        Task<bool> AddTokenToUser(UserEntity user, RefreshTokenEntity refreshToken);
        Task<bool> RenewPassword(UserEntity user, HashPasswordEntity hashPasswordEntity);
    }
}