using Services.Models.Command;
namespace Services
{
    public interface IAuthService
    {
        public Task<bool> SignUp(UserSignUpCommand user);
        public Task<TokenCommand> UserSignInWithPassword(UserSignInWithPasswordCommand user);
        public Task<TokenCommand> UserSignInWithRefreshToken(UserSignInWithRefreshTokenCommand user);


    }
}

