using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;

namespace HairdresserAPI.Interfaces;

public interface IUserManagementPrivateService
{
    Task<UserResponseDTO> RegisterUserAsync(RegistrationDto registrationDto);
    Task<UserResponseDTO> AuthenticateUserAsync(LoginDto loginDto);
}
