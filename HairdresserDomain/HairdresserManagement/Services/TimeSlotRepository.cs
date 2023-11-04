using HairdresserAPI.DatabaseContext;

namespace HairdresserAPI.HairdresserDomain.HairdresserManagement.Services;

public class TimeSlotRepository
{
    private readonly AppDbContext _context;

    public TimeSlotRepository(AppDbContext context)
    {
        _context = context;
    }
}
