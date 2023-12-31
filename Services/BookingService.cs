using HairdresserAPI.Domains.HairdresserDomain.DTO;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;

namespace HairdresserAPI.Services;

public class BookingService : IBookingPrivateService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ITimeSlotRepository _timeSlotRepository;

    public BookingService(IBookingRepository bookingRepository, ITimeSlotRepository timeSlotRepository)
    {
        _bookingRepository = bookingRepository;
        _timeSlotRepository = timeSlotRepository;
    }

    public async Task<Booking> AddBooking(BookingDto bookingDto)
    {
        var booking = new Booking(bookingDto.AppointmentDate, Guid.Parse(bookingDto.UserId), Guid.Parse(bookingDto.HairdresserId));
        await _bookingRepository.AddAsync(booking);

        return booking;
    }

    public async Task<Booking> CompleteBooking(Guid guid)
    {
        var booking = await _bookingRepository.MarkAsCompleted(guid);
        return booking;
    }

    public async Task<List<Booking>> GetMyBookings(Guid userId)
    {
        var bookings = await _bookingRepository.GetManyById(userId);

        return bookings;
    }

    public async Task<List<Booking>> GetMyBookingsByHairdresser(Guid guid)
    {
        var bookings = await _bookingRepository.GetManyByHairdresserId(guid);

        return bookings;
    }

    public async Task<Booking> RemoveBooking(Guid guid)
    {
        var booking = await _bookingRepository.Remove(guid);
        await _timeSlotRepository.UnreserveTimeSlot(booking.AppointmentDate);

        return booking;
    }

}
