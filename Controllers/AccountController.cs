using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;
using HairdresserAPI.UserDomain.UserManagement;
using HairdresserAPI.UserDomain.UserManagement.Interfaces;
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
    public async Task<ActionResult<UserResponseDTO>> Register(RegistrationDto registrationDto)
    {
        var userDto = await _userManagementPrivateService.RegisterUserAsync(registrationDto);
        return Ok(userDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserResponseDTO>> Login(LoginDto loginDto)
    {
        var userDto = await _userManagementPrivateService.AuthenticateUserAsync(loginDto);
        return Ok(userDto);
    }
}
