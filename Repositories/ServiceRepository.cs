using HairdresserAPI.DatabaseContext;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAPI.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task<Service> GetById(Guid id)
    {
        var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
        return service;
    }

    public async Task MarkAsCompleted(Guid guid)
    {
        var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == guid);

        if (service != null)
        {
            service.MarkAsCompleted();
        }
        await _context.SaveChangesAsync();
    }
}