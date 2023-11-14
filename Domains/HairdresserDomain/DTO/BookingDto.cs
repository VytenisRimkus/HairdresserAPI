namespace HairdresserAPI.Domains.HairdresserDomain.DTO;

public record BookingDto
{
    public string UserId { get; set; }
    public string HairdresserId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public bool IsCompleted { get; set; }
}
