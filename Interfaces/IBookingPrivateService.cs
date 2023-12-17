using HairdresserAPI.Domains.HairdresserDomain.DTO;
using HairdresserAPI.Domains.UserDomain.Enums;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;

namespace HairdresserAPI.Interfaces;

public interface IBookingPrivateService
{
    Task<Booking> AddBooking(BookingDto bookingDto);
    Task<Booking> CompleteBooking(Guid guid);
    Task<List<Booking>> GetMyBookings(Guid userId);
    Task<List<Booking>> GetMyBookingsByHairdresser(Guid guid);
    Task<Booking> RemoveBooking(Guid guid);
}