using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;
using HairdresserAPI.UserDomain.UserManagement;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAPI.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IUserManagementPrivateService _userManagementPrivateService;
    public AccountController(IUserManagementPrivateService userManagementPrivateService)
    {
        _userManagementPrivateService = userManagementPrivateService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(RegistrationDto registrationDto)
    {
        var user = await _userManagementPrivateService.RegisterUserAsync(registrationDto);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(LoginDto loginDto)
    {
        var user = await _userManagementPrivateService.AuthenticateUserAsync(loginDto);
        return Ok(user);
    }
}
