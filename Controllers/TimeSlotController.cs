using HairdresserAPI.HairdresserDomain.HairdresserDtos;
using HairdresserAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAPI.Controllers;

[Route("timeSlot")]
[ApiController]
public class TimeSlotController : ControllerBase
{
    private readonly ITimeSlotPrivateService _timeSlotService;

    public TimeSlotController(ITimeSlotPrivateService timeSlotService)
    {
        _timeSlotService = timeSlotService;
    }

    [HttpPost("createTimeSlot")]
    public async Task<IActionResult> CreateTimeSlot([FromBody] TimeSlotCreationDto creationDto, string hairdresserId)
    {
        var timeSlotDto = await _timeSlotService.CreateTimeSlotAsync(creationDto, Guid.Parse(hairdresserId));
        return Ok(timeSlotDto);
    }

    [HttpGet("getTimeSlots")]
    public async Task<ActionResult<IEnumerable<TimeSlotDto>>> GetTimeSlotsByHairdresserId(Guid hairdresserId)
    {
        var timeSlots = await _timeSlotService.GetTimeSlotsByHairdresserIdAsync(hairdresserId);
        return Ok(timeSlots);
    }

    [HttpPut("updateTimeSlot")]
    public async Task<IActionResult> UpdateTimeSlot(Guid id, [FromBody] TimeSlotUpdateDto updateDto)
    {
        await _timeSlotService.UpdateTimeSlotAsync(id, updateDto);
        return NoContent();
    }


    [HttpDelete("deleteTimeSlot")]
    public async Task<IActionResult> DeleteTimeSlot(Guid id)
    {
        try
        {
            await _timeSlotService.DeleteTimeSlotAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
