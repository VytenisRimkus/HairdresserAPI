using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.UserDomain.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAPI.DatabaseContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(e => e.UserType)
            .HasConversion<string>();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Hairdresser> Hairdressers { get; set; }
    public DbSet<Review> Reviews { get; set; }
}
