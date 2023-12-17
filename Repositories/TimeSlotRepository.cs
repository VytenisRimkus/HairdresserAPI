using HairdresserAPI.DatabaseContext;
using HairdresserAPI.Domains.UserDomain.Enums;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAPI.Repositories;

public class TimeSlotRepository : ITimeSlotRepository
{
    private readonly AppDbContext _context;

    public TimeSlotRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddTimeSlotAsync(TimeSlot timeSlot)
    {
        await _context.TimeSlots.AddAsync(timeSlot);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TimeSlot>> GetTimeSlotsByHairdresserId(Guid hairdresserId)
    {
        return await _context.TimeSlots
                             .Where(ts => ts.HairdresserId == hairdresserId)
                             .ToListAsync();
    }

    public async Task UpdateTimeSlotAsync(TimeSlot timeSlot)
    {
        _context.TimeSlots.Update(timeSlot);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTimeSlotAsync(Guid timeSlotId)
    {
        var timeSlot = await _context.TimeSlots.FindAsync(timeSlotId);
        if (timeSlot != null)
        {
            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<TimeSlot> GetTimeSlotByIdAsync(Guid timeSlotId)
    {
        return await _context.TimeSlots.FindAsync(timeSlotId);
    }

    public async Task<bool> HasOverlap(Guid hairdresserId, DateTime startTime, DateTime endTime)
    {
        return await _context.TimeSlots
            .AnyAsync(ts => ts.HairdresserId == hairdresserId &&
                            ((startTime >= ts.StartTime && startTime < ts.EndTime) ||
                             (endTime > ts.StartTime && endTime <= ts.EndTime) ||
                             (ts.StartTime >= startTime && ts.StartTime < endTime)));
    }

    public async Task UpdateTimeSlotStateAsync(Guid guid)
    {
        var timeSlot = await _context.TimeSlots.FirstOrDefaultAsync(x => x.Id == guid);

        if (timeSlot == null)
        {
            throw new KeyNotFoundException("TimeSlot not found.");
        }

        timeSlot.IsBooked = !timeSlot.IsBooked;

        _context.Entry(timeSlot).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task UnreserveTimeSlot(DateTime appointmentDate)
    {
        var timeSlot = await _context.TimeSlots.FirstOrDefaultAsync(x => x.StartTime == appointmentDate);

        if (timeSlot == null)
            throw new KeyNotFoundException("TimeSlot not found.");

        timeSlot.IsBooked = false;
        _context.Entry(timeSlot).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

