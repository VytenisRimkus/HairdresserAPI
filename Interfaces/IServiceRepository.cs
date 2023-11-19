using HairdresserAPI.HairdresserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;

public interface IServiceRepository
{
    Task<Service> AddService(Service service);
    Task<Service> FindById (Guid serviceId);
}