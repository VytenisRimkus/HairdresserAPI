using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairdresserAPI.SharedDomain;

namespace HairdresserAPI.HairdresserDomain.Aggregate;

public class TimeSlot : BaseEntity
{
    public TimeSlot()
    {
    }

    public TimeSlot(DateTime startTime, DateTime endTime, Guid hairdresserId)
    {
        StartTime = startTime;
        EndTime = endTime;
        HairdresserId = hairdresserId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    public Guid HairdresserId { get; set; }
    public Hairdresser Hairdresser { get; set; }

    public bool IsBooked { get; set; }
}
