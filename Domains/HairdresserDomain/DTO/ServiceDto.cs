
namespace HairdresserAPI.HairdresserDomain.HairdresserDtos;

public record ServiceDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid HairdresserId { get; set; }
}