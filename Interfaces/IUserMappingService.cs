using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;

namespace HairdresserAPI.Interfaces;

public interface IUserMappingService
{
    UserResponseDTO MapUserResponseDto(User source);
}
