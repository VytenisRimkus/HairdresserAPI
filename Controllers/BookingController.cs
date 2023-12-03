using HairdresserAPI.Domains.HairdresserDomain.DTO;
using HairdresserAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAPI.Controllers;

[ApiController]
[Route("booking")]
public class BookingController : ControllerBase
{
    private readonly IBookingPrivateService _bookingService;

    public BookingController(IBookingPrivateService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost("addBooking")]
    public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
    {
        await _bookingService.AddBooking(bookingDto);
        return Ok();
    }

    [HttpGet("getBookings/{userId}")]
    public async Task<IActionResult> GetBookings(string userId)
    {
        var bookings = await _bookingService.GetMyBookings(Guid.Parse(userId));
        return Ok(bookings);
    }

    [HttpGet("getHairdresserBookings/{id}")]
    public async Task<IActionResult> GetBookingsByHairdresser(string id)
    {
        var bookings = await _bookingService.GetMyBookingsByHairdresser(Guid.Parse(id));
        return Ok(bookings);
    }

    [HttpPut("completeBooking/{id}")]
    public async Task<IActionResult> CompleteBooking(string id)
    {
        var booking = await _bookingService.CompleteBooking(Guid.Parse(id));
        return Ok(booking);
    }
}
