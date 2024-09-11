using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Services;
using Services.Models.Auth;
using Services.Models.Common;
using Services.Models.Req;

namespace Presentation.Controllers;

[ApiController]
[Route("Auth")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }
    [HttpPost("SignUp")]
    public async Task<ActionResult<Boolean>> SignUp([FromBody] UserSignUp user)
    {
        try
        {
            var data = await _authService.SignUp(user);
            return NoContent();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPost("SignIn")]
    public async Task<ActionResult<Token>> SignUp([FromBody] GrantRequest grant)
    {
        try
        {
            switch (grant.GrantType)
            {
                case "password":
                    return Ok(await _authService.UserSignInWithPassword((UserSignInWithPassword)grant.GrantDetails));
                case "refreshToken":
                    return Ok(await _authService.UserSignInWithRefreshToken((UserSignInWithRefreshToken)grant.GrantDetails));
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