using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairdresserAPI.SharedDomain;
using HairdresserAPI.UserDomain.Aggregate;

namespace HairdresserAPI.HairdresserDomain.Aggregate;

public class Booking : BaseEntity
{
    public Booking()
    {
    }

    public Booking(DateTime appointmentDate, Guid userId, Guid hairdresserId)
    {
        AppointmentDate = appointmentDate;
        UserId = userId;
        HairdresserId = hairdresserId;
        IsCompleted = false;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AppointmentDate { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    [ForeignKey("Hairdresser")]
    public Guid HairdresserId { get; set; }
    public virtual Hairdresser Hairdresser { get; set; }

    [Column(TypeName = "bit")]
    public bool IsCompleted { get; set; }
}
