using Services.Models.Command;
namespace Services
{
    public interface IAuthService
    {
        Task<bool> SignUp(UserSignUpCommand user);
        Task<TokenCommand> UserSignInWithPassword(UserSignInWithPasswordCommand user);
        Task<TokenCommand> UserSignInWithRefreshToken(UserSignInWithRefreshTokenCommand user);
    }
}

