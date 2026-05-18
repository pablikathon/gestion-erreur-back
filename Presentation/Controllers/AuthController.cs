using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Presentation.Models.Auth;

using Services;
using Services.Models.Auth;
using Services.Models.Command;

namespace Presentation.Controllers;

[ApiController]
[Route("Auth")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper)
    {
        this._authService = authService;
        this._mapper = mapper;
    }
    [HttpPost("SignUp")]
    public async Task<ActionResult<Boolean>> SignUp([FromBody] UserSignUpRequest user)
    {
        try
        {
            var userCommand = _mapper.Map<UserSignUpCommand>(user);
            var data = await _authService.SignUp(userCommand);
            return NoContent();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPost("SignIn")]
    public async Task<ActionResult<TokenCommand>> SignIn([FromBody] GrantTypeRequest grant)
    {
        try
        {
            switch (grant.GrantType)
            {
                case "password":
                    return Ok(await _authService.UserSignInWithPassword(
                     new UserSignInWithPasswordCommand { Email = grant.GrantDetails.Email, Password = ((UserSignInWithPasswordRequest)grant.GrantDetails).Password })
                    );
                case "refreshToken":
                    return Ok(await _authService.UserSignInWithRefreshToken(
                        new UserSignInWithRefreshTokenCommand { Email = grant.GrantDetails.Email, RefreshToken = ((UserSignInWithRefreshTokenRequest)grant.GrantDetails).RefreshToken }));
                default:
                    return NotFound($"{grant.GrantType} is not a valid grant type");
            }
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

}
