using HairdresserAPI.HairdresserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;

public interface ITimeSlotRepository
{
    Task AddTimeSlotAsync(TimeSlot timeSlot);
    Task<IEnumerable<TimeSlot>> GetTimeSlotsByHairdresserId(Guid hairdresserId);
    Task UpdateTimeSlotAsync(TimeSlot timeSlot);
    Task DeleteTimeSlotAsync(Guid timeSlotId);
    Task<TimeSlot> GetTimeSlotByIdAsync(Guid timeSlotId);
    Task<bool> HasOverlap(Guid hairdresserId, DateTime startTime, DateTime endTime);
}
