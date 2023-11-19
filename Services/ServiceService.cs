using HairdresserAPI.Domains.HairdresserDomain.DTO;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.Interfaces;

namespace HairdresserAPI.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Service> AddService(ServiceDto serviceDto)
    {
        var service = new Service(serviceDto.Name, serviceDto.Description, serviceDto.Price, serviceDto.Duration, serviceDto.HairdresserId);

        await _serviceRepository.AddService(service);

        return service;
    }

    public async Task<Service> FindById (Guid serviceId)
    {
        var service = await _serviceRepository.FindById(serviceId);

        return service;
    }
}