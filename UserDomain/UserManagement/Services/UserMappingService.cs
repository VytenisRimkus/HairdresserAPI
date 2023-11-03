using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.UserDTO;
using HairdresserAPI.UserDomain.UserManagement.Interfaces;

namespace HairdresserAPI.UserDomain.UserManagement.Services;

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


