using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;

namespace HairdresserAPI.Services;

public class ServiceBookingService : IServiceBookingService
{
    private readonly IServiceRepository _serviceRepository;
    public ServiceBookingService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Service> CreateService(Service service)
    {
        var newService = new Service(service.Name, service.Description, service.Price, service.Duration, service.HairdresserId);
        await _serviceRepository.AddAsync(newService);
        return newService;
    }

    public async Task<Service> GetService(Guid guid)
    {
        var service = await _serviceRepository.GetById(guid) ?? throw new Exception("Service not found");
        return service;
    }
}