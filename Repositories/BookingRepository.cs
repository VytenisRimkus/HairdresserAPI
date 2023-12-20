using HairdresserAPI.DatabaseContext;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAPI.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Booking>> GetManyByHairdresserId(Guid guid)
    {
        return await _context.Bookings.Where(x => x.HairdresserId == guid).Where(x => x.IsCompleted == false || x.IsCompleted == null).ToListAsync();
    }

    public async Task<List<Booking>> GetManyById(Guid userId)
    {
        return await _context.Bookings.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<Booking> MarkAsCompleted(Guid guid)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == guid);

        if (booking != null)
        {
            booking.MarkAsCompleted();
            await _context.SaveChangesAsync();
            return booking;
        }

        throw new Exception("Booking not found");
    }

    public async Task<Booking> Remove(Guid guid)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == guid);

        if (booking != null && booking.IsCompleted == false) 
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        throw new Exception("Booking not found");
    }
}