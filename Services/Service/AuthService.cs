using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Persist;
using Persist.Entities;
using Repositories;
using Services.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly string Key;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IPasswordHasherService _passwordHasherService;
        public AuthService(IAuthRepository authRepository, IMapper mapper, AppDbContext context, IPasswordHasherService passwordHasherService)
        {
            _authRepository = authRepository;
            Key = "Tempory string";
            _mapper = mapper;
            _context = context;
            _passwordHasherService = passwordHasherService;
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
            var u = _context.User.First(u => u.Email == user.Email && u.IsEmailConfirmed);
            if (u == null)
            {
                throw new EntryPointNotFoundException("No verified user founded");
            }
            if (_passwordHasherService.Validate(u.HashPasswordEntity.Password, user.Password))
            {
                try
                {
                    var AccessToken = GenerateToken(user.Email);
                    var RefreshToken = GenerateRefreshToken();
                    if (await _authRepository.AddTokenToUser(u, new RefreshTokenEntity() { Id = Guid.NewGuid().ToString(), RefreshToken = RefreshToken }))
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

        public Task<Token> UserSignInWithRefreshToken(UserSignInWithRefreshToken user)
        {
            throw new NotImplementedException();
        }
        public string GenerateToken(string Email)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(this.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public bool IsUserExist(string Email)
        {
            return _context.User.First(u => u.Email == Email) == null;
        }

        public bool IsUserEmailConfirmed(string Email)
        {
            return _context.User.First(u => u.Email == Email && u.IsEmailConfirmed) == null;
        }
    }
}