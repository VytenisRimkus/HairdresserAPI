using HairdresserAPI.DatabaseContext;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAPI.Repositories;

public class HairdresserRepository : IHairdresserRepository
{
    private readonly AppDbContext _context;

    public HairdresserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Hairdresser> GetByIdAsync(Guid id)
    {
        var hairdresser = await _context.Hairdressers
            .Include(h => h.AvailableTimeSlots)
            .Include(h => h.Bookings)
            .Include(h => h.Reviews)
            .FirstOrDefaultAsync(h => h.Id == id);
        
        return hairdresser;
    }

    public async Task<List<Hairdresser>> GetAllAsync()
    {
        return await _context.Hairdressers.ToListAsync();
    }

    public async Task AddAsync(Hairdresser hairdresser)
    {
        await _context.Hairdressers.AddAsync(hairdresser);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Hairdresser hairdresser)
    {
        _context.Hairdressers.Update(hairdresser);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Hairdresser hairdresser)
    {
        _context.Hairdressers.Remove(hairdresser);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Hairdresser>> GetManyByIdAsync(Guid guid)
    {
        var hairdressers = await _context.Hairdressers
            .Where(x => x.CreatedByUserId == guid)
            .ToListAsync();

        return hairdressers;
    }

    public async Task<List<Hairdresser>> GetManyAsync()
    {
        return await _context.Hairdressers.ToListAsync();
    }
}
