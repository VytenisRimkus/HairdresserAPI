using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;

namespace HairdresserAPI.UserDomain.UserManagement.Interfaces;

public interface IUserManagementPrivateService
{
    Task<User> RegisterUserAsync(RegistrationDto registrationDto);
    Task<User> AuthenticateUserAsync(LoginDto loginDto);
}
