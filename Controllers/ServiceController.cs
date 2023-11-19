using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;

namespace HairdresserAPI.Controllers;

[ApiController]
[Route("service")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;
    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpPost("add")]
    public async Task<Service> AddService(ServiceDto service)
    {
        var service = await _serviceService.AddService(service);
        return Ok(userDto);
    }
}
