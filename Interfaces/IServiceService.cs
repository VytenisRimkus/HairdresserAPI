using HairdresserAPI.HairdresserDomain.DTO;

namespace HairdresserAPI.Interfaces;

public interface IServiceService
{
    Task<Service> AddService(ServiceDto service);
    Task<Service> FindById (Guid serviceId);
}