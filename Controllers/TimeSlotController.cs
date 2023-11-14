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

    [HttpPost("createTimeSlot/{hairdresserId}")]
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

    [HttpPut("updateTimeSlotState/{id}")]
    public async Task<IActionResult> UpdateTimeSlotState(string id)
    {
        await _timeSlotService.UpdateTimeSlotStateAsync(Guid.Parse(id));
        return NoContent();
    }


    [HttpDelete("deleteTimeSlot/{id}")]
    public async Task<IActionResult> DeleteTimeSlot(string id)
    {
        try
        {
            await _timeSlotService.DeleteTimeSlotAsync(Guid.Parse(id));
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
