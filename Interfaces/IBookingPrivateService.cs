using HairdresserAPI.Domains.HairdresserDomain.DTO;
using HairdresserAPI.Domains.UserDomain.Enums;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;

namespace HairdresserAPI.Interfaces;

public interface IBookingPrivateService
{
    Task<Booking> AddBooking(BookingDto bookingDto);
    Task<List<Booking>> GetMyBookings(Guid userId);
}