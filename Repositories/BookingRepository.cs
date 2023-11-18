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

    public async Task<List<Booking>> GetManyById(Guid userId)
    {
        return await _context.Bookings.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<Booking> GetById(string bookingId)
    {
        var booking = await _context.Bookings.Where(x => x.Id == Guid.Parse(bookingId)).FirstOrDefaultAsync();

        return booking;
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}