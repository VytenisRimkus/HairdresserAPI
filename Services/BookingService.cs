using HairdresserAPI.Domains.HairdresserDomain.DTO;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;

namespace HairdresserAPI.Services;

public class BookingService : IBookingPrivateService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<Booking> AddBooking(BookingDto bookingDto)
    {
        var booking = new Booking(bookingDto.AppointmentDate, Guid.Parse(bookingDto.UserId), Guid.Parse(bookingDto.HairdresserId));
        await _bookingRepository.AddAsync(booking);

        return booking;
    }

    public async Task<List<Booking>> GetMyBookings(Guid userId)
    {
        var bookings = await _bookingRepository.GetManyById(userId);

        return bookings;
    }

}
