namespace HairdresserAPI.HairdresserDomain.HairdresserDtos;

public record HairdresserDto
{
    public string Name { get; init; }
    public string Biography { get; init; }
    public string Location { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
}

public record CreateHairdresserDto
{
    public string Name { get; init; }
    public string Biography { get; init; }
    public string Location { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public Guid CreatedByUserId { get; init; }
}

public record UpdateHairdresserDto
{
    public string Name { get; init; }
    public string Biography { get; init; }
    public string Location { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
}