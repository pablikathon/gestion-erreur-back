using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;
using Repositories;
using Services.Models.Auth;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ISecurityService _securityService;
        public AuthService(IAuthRepository authRepository, IMapper mapper, AppDbContext context, ISecurityService securityService)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _context = context;
            _securityService = securityService;
        }
        public async Task<bool> SignUp(UserSignUp user)
        {
            if (this.IsUserExist(user.Email))
            {
                throw new EntryPointNotFoundException("User Already Exist");
            }
            return await _authRepository.Signup(_mapper.Map<UserEntity>(user));
        }

        public async Task<Token> UserSignInWithPassword(UserSignInWithPassword user)
        {
            //En attendant d'implémenter la confirmation d'email
            var u = _context.User.Include(p => p.HashPasswordEntity)
            .First(u => u.Email == user.Email /*&& u.IsEmailConfirmed*/) ?? throw new Exception("No verified user founded");
            if (_securityService.Validate(u.HashPasswordEntity.Password, user.Password))
            {
                try
                {
                    var AccessToken = _securityService.GenerateAccessToken(user.Email);
                    var RefreshToken = _securityService.GenerateRefreshToken();
                    if (await _authRepository.AddTokenToUser(u, new RefreshTokenEntity() { Id = Guid.NewGuid().ToString(), RefreshToken =_securityService.Hash(RefreshToken), CreatedAt = DateTime.Now }))
                    {
                        return new Token { AccessToken = AccessToken, RefreshToken = RefreshToken };
                    }
                    throw new Exception("Error updt user refresh token in db");
                }
                catch (System.Exception)
                {
                    throw;
                }

            }
            throw new Exception("Bad Password");
        }

        public async Task<Token> UserSignInWithRefreshToken(UserSignInWithRefreshToken user)
        {
            //En attendant d'implémenter la confirmation d'email
            var u = _context.User.Include(p => p.RefreshToken)
            .First(u => u.Email == user.Email /*&& u.IsEmailConfirmed*/) ?? throw new Exception("No verified user founded");
            if ( _securityService.Validate(u?.RefreshToken?.RefreshToken ?? throw new Exception ("User have no refresh token"), user.RefreshToken))
            {
                try
                {
                    var AccessToken = _securityService.GenerateAccessToken(user.Email);
                    var RefreshToken = _securityService.GenerateRefreshToken();
                    if (await _authRepository.AddTokenToUser(u, new RefreshTokenEntity() { Id = Guid.NewGuid().ToString(), RefreshToken = _securityService.Hash(RefreshToken), CreatedAt = DateTime.Now }))
                    {
                        return new Token { AccessToken = AccessToken, RefreshToken = RefreshToken };
                    }
                    throw new Exception("Error updt user refresh token in db");
                }
                catch (System.Exception)
                {
                    throw;
                }

            }
            throw new Exception("Bad Password");
        }

        public bool IsUserExist(string Email)
        {
            return _context.User.FirstOrDefault(u => u.Email == Email) != null;
        }

        public bool IsUserEmailConfirmed(string Email)
        {
            return _context.User.FirstOrDefault(u => u.Email == Email && u.IsEmailConfirmed) == null;
        }
    }
}