using HairdresserAPI.UserDomain.Enums;

namespace HairdresserAPI.UserDomain.UserDTO;

public record RegistrationDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string UserType { get; set; }
}
