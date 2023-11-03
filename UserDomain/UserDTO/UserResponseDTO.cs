namespace HairdresserAPI.UserDomain.UserDTO;

public record UserResponseDTO
{
    public required string Username { get; init; }
    public required string UserType { get; init; }
    public required DateTime CreatedDate { get; init; }
}
