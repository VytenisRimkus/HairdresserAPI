using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserAPI.Controllers;

[ApiController]
[Route("service")]
public class ServiceController : ControllerBase
{
    private readonly IServiceBookingService _serviceBookingService;

    public ServiceController(IServiceBookingService serviceBookingService)
    {
        _serviceBookingService = serviceBookingService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Service>> Create([FromBody] Service service)
    {
        var createdService = await _serviceBookingService.CreateService(service);
        return Ok(createdService);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Service>> GetService(string id)
    {
        var service = await _serviceBookingService.GetService(Guid.Parse(id));
        return Ok(service);
    }
}
