using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;

namespace HairdresserAPI.UserDomain.UserManagement.Interfaces;

public interface IUserManagementPrivateService
{
    Task<UserResponseDTO> RegisterUserAsync(RegistrationDto registrationDto);
    Task<UserResponseDTO> AuthenticateUserAsync(LoginDto loginDto);
}
