using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;

namespace HairdresserAPI.UserDomain.UserManagement.Interfaces;

public interface IUserMappingService
{
    UserResponseDTO MapUserResponseDto(User source);
}
