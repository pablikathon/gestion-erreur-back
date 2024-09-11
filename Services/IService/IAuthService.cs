using Services.Models.Auth;
namespace Services
{
    public interface IAuthService
    {
        public Task<bool> SignUp(UserSignUp user);
        public Task<Token> UserSignInWithPassword(UserSignInWithPassword user);
        public Task<Token> UserSignInWithRefreshToken(UserSignInWithRefreshToken user);


    }
}

