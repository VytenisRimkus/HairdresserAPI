using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairdresserAPI.SharedDomain;
using HairdresserAPI.UserDomain.Aggregate;

namespace HairdresserAPI.HairdresserDomain.Aggregate;

public class Review : BaseEntity
{
    public Review()
    {
    }

    public Review(string content, int rating, Guid hairdresserId, Guid userId)
    {
        Content = content;
        Rating = rating;
        HairdresserId = hairdresserId;
        UserId = userId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string Content { get; set; }

    [Column(TypeName = "smallint")]
    public int Rating { get; set; }

    [ForeignKey("Hairdresser")]
    public Guid HairdresserId { get; set; }
    public virtual Hairdresser Hairdresser { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
