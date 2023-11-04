using HairdresserAPI.DatabaseContext;
using HairdresserAPI.HairdresserDomain.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAPI.HairdresserDomain.HairdresserRepository;

public class HairdresserRepository : IHairdresserRepository
{
    private readonly AppDbContext _context;

    public HairdresserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Hairdresser> GetByIdAsync(Guid id)
    {
        return await _context.Hairdressers.FindAsync(id);
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
}
