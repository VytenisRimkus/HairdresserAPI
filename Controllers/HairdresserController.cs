using HairdresserAPI.HairdresserDomain.HairdresserDtos;
using HairdresserAPI.HairdresserDomain.HairdresserManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAPI.Controllers;

[ApiController]
[Route("hairdresser")]
public class HairdresserController : ControllerBase
{
    private readonly IHairdresserPrivateService _hairdresserPrivateService;

    public HairdresserController(IHairdresserPrivateService hairdresserPrivateService)
    {
        _hairdresserPrivateService = hairdresserPrivateService;
    }

    [HttpPost("createHairdresser")]
    public async Task<ActionResult<HairdresserDto>> Create(CreateHairdresserDto createHairdresserDto, string userId)
    {
        var hairdresserDto = await _hairdresserPrivateService.CreateHairdresserAsync(createHairdresserDto, Guid.Parse(userId));
        return Ok(hairdresserDto);
    }

    [HttpGet("get")]
    public async Task<ActionResult<HairdresserDto>> GetById(Guid id)
    {
        var hairdresserDto = await _hairdresserPrivateService.GetHairdresserByIdAsync(id);
        return Ok(hairdresserDto);
    }

    [HttpPut("updateHairdresser")]
    public async Task<ActionResult<HairdresserDto>> Update(Guid id, UpdateHairdresserDto updateHairdresserDto, string userId)
    {
        var updatedHairdresserDto = await _hairdresserPrivateService.UpdateHairdresserAsync(id, updateHairdresserDto, Guid.Parse(userId));
        return Ok(updatedHairdresserDto);
    }

    // Delete a hairdresser
    [HttpDelete("deleteHairdresser")]
    public async Task<IActionResult> Delete(Guid id, string userId)
    {
        try
        {
            await _hairdresserPrivateService.DeleteHairdresserAsync(id, Guid.Parse(userId));
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}