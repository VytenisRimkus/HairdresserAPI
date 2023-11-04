using HairdresserAPI.UserDomain.Enums;

namespace HairdresserAPI.UserDomain.UserDTO;

public record RegistrationDto
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string UserType { get; init; }
}
