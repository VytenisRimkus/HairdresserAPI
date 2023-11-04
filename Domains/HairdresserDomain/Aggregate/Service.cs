using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairdresserAPI.SharedDomain;

namespace HairdresserAPI.HairdresserDomain.Aggregate;

public class Service : BaseEntity
{
    public Service()
    {
    }

    public Service(string name, string description, decimal price, TimeSpan duration, Guid hairdresserId)
    {
        Name = name;
        Description = description;
        Price = price;
        Duration = duration;
        HairdresserId = hairdresserId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]

    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string Description { get; set; }


    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }

    [ForeignKey("Hairdresser")]
    public Guid HairdresserId { get; set; }
    public virtual Hairdresser Hairdresser { get; set; }
}
