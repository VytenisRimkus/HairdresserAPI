using HairdresserAPI.HairdresserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);
    Task<List<Booking>> GetManyById(Guid userId);
    Task<Booking> GetById(string bookingId);
    Task Save();

}

