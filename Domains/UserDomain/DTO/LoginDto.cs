namespace HairdresserAPI.UserDomain.UserDTO;

public record LoginDto
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}
