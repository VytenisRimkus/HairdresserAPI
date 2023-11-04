namespace HairdresserAPI.HairdresserDomain.HairdresserDtos;

public record TimeSlotDto
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

public record TimeSlotCreationDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

public record TimeSlotUpdateDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}