using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HairdresserAPI.Interfaces;
using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HairdresserAPI.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IUserManagementPrivateService _userManagementPrivateService;
    private readonly IAuthService _authService;
    public AccountController(IUserManagementPrivateService userManagementPrivateService, IAuthService authService)
    {
        _userManagementPrivateService = userManagementPrivateService;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserResponseDTO>> Register(RegistrationDto registrationDto)
    {
        var userDto = await _userManagementPrivateService.RegisterUserAsync(registrationDto);
        return Ok(userDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManagementPrivateService.AuthenticateUserAsync(loginDto);
        var token = _authService.GenerateJwtToken(user);
        return Ok(new { token, username = user.Username, role = user.UserType, id = user.Id });
    }
}
