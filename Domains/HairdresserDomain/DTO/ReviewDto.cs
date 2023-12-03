namespace HairdresserAPI.HairdresserDomain.HairdresserDtos;

public class ReviewDto
{
    public string UserId { get; set; }
    public string HairdresserId { get; set; }
    public int Rating { get; set; }
    public string Content { get; set; }
}