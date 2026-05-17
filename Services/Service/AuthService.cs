using AutoMapper;

using exception.Message;



using Persist.Entities.Auth;

using Repositories;

using Services.Models.Command;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;
        private readonly IUserRepository _userRepository;
        public AuthService(IAuthRepository authRepository, IMapper mapper, ISecurityService securityService, IUserRepository userRepository)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _securityService = securityService;
            _userRepository = userRepository;
        }
        public async Task<bool> SignUp(UserSignUp user)
        {
            if (await _userRepository.IsUserExist(user.Email))
            {
                throw new InvalidOperationException(AuthMessage.UserAlreadyExist);
            }
            var u = _mapper.Map<UserEntity>(user);
            var id = Guid.NewGuid().ToString();
            u.HashPasswordId = id;
            u.HashPasswordEntity = new HashPasswordEntity
            {
                Id = id,
                Password = _securityService.Hash(user.Password),
                CreatedAt = DateTime.UtcNow
            };
            return await _userRepository.CreateUser(u);
        }
        public async Task<Token> UserSignInWithPassword(UserSignInWithPassword user)
        {
            //En attendant d'implémenter la confirmation d'email
            var u = await _userRepository.GetUserByEmail(user.Email) ?? throw new Exception(AuthMessage.NoVerifiedUserFound);
            if (_securityService.Validate(u.HashPasswordEntity.Password, user.Password))
            {
                try
                {
                    var AccessToken = _securityService.GenerateAccessToken(u);
                    var RefreshToken = _securityService.GenerateRefreshToken();
                    if (await _authRepository.AddTokenToUser(u, new RefreshTokenEntity() { Id = Guid.NewGuid().ToString(), RefreshToken = _securityService.Hash(RefreshToken), CreatedAt = DateTime.Now }))
                    {
                        return new Token { AccessToken = AccessToken, RefreshToken = RefreshToken };
                    }
                    throw new Exception(AuthMessage.ErrorUpdateUserToken);
                }
                catch
                {
                    throw;
                }

            }
            throw new Exception(AuthMessage.WrongPassword);
        }

        public async Task<Token> UserSignInWithRefreshToken(UserSignInWithRefreshToken user)
        {
            //En attendant d'implémenter la confirmation d'email
            var u = await _userRepository.GetUserByToken(user.RefreshToken) ?? throw new Exception(AuthMessage.NoVerifiedUserFound);
            if (_securityService.Validate(u?.RefreshToken?.RefreshToken ?? throw new Exception(AuthMessage.RefreshTokenNotFound), user.RefreshToken))
            {
                try
                {
                    var AccessToken = _securityService.GenerateAccessToken(u);
                    var RefreshToken = _securityService.GenerateRefreshToken();
                    if (await _authRepository.AddTokenToUser(u, new RefreshTokenEntity() { Id = Guid.NewGuid().ToString(), RefreshToken = _securityService.Hash(RefreshToken), CreatedAt = DateTime.Now }))
                    {
                        return new Token { AccessToken = AccessToken, RefreshToken = RefreshToken };
                    }
                    throw new Exception(AuthMessage.ErrorUpdateUserToken);
                }
                catch (System.Exception)
                {
                    throw;
                }

            }
            throw new Exception(AuthMessage.WrongToken);
        }


    }
}
