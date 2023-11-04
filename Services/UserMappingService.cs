using HairdresserAPI.Interfaces;
using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;

namespace HairdresserAPI.Services;

public class UserMappingService : IUserMappingService
{
    public UserMappingService()
    {
    }

    public UserResponseDTO MapUserResponseDto(User source) =>
        new()
        {
            Username = source.Username,
            UserType = source.UserType.ToString(),
            CreatedDate = source.CreatedDate
        };
}


