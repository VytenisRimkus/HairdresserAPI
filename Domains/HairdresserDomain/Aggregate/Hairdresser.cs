using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairdresserAPI.SharedDomain;

namespace HairdresserAPI.HairdresserDomain.Aggregate;

public class Hairdresser : BaseEntity
{
    public Hairdresser()
    {
    }

    public Hairdresser(string name, string biography, string location, string phoneNumber, string email, Guid createdByUserId)
    {
        Name = name;
        Biography = biography;
        Location = location;
        PhoneNumber = phoneNumber;
        Email = email;
        CreatedByUserId = createdByUserId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Biography { get; set; }

    [StringLength(50)]
    public string Location { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<TimeSlot> AvailableTimeSlots { get; set; } = new List<TimeSlot>();

    [StringLength(20)]
    public string PhoneNumber { get; set; }

    [StringLength(30)]
    public string Email { get; set; }

    public Guid CreatedByUserId { get; set; }
}
