using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;
using HairdresserAPI.Interfaces;
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

    [HttpPost("createHairdresser/{userId}")]
    public async Task<ActionResult<HairdresserDto>> Create(CreateHairdresserDto createHairdresserDto, string userId)
    {
        var hairdresserDto = await _hairdresserPrivateService.CreateHairdresserAsync(createHairdresserDto, Guid.Parse(userId));
        return Ok(hairdresserDto);
    }

    [HttpGet("getListById/{userId}")]
    public async Task<ActionResult<Hairdresser>> GetHairdresserListById(string userId)
    {
        var hairdresserDto = await _hairdresserPrivateService.GetHairdresserListByIdAsync(Guid.Parse(userId));
        return Ok(hairdresserDto);
    }

    [HttpGet("getListById")]
    public async Task<ActionResult<Hairdresser>> GetHairdresserList()
    {
        var hairdresserDto = await _hairdresserPrivateService.GetHairdresserListAsync();
        return Ok(hairdresserDto);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<HairdresserDto>> GetById(string id)
    {
        var hairdresserDto = await _hairdresserPrivateService.GetHairdresserByIdAsync(Guid.Parse(id));
        return Ok(hairdresserDto);
    }

    [HttpPut("updateHairdresser/{id}")]
    public async Task<ActionResult<HairdresserDto>> Update(string id, UpdateHairdresserDto updateHairdresserDto)
    {
        var updatedHairdresserDto = await _hairdresserPrivateService.UpdateHairdresserAsync(Guid.Parse(id), updateHairdresserDto);
        return Ok(updatedHairdresserDto);
    }

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