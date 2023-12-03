using HairdresserAPI.HairdresserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;

public interface IServiceRepository
{
    Task AddAsync(Service service);

    Task<Service> GetById(Guid id);
    Task MarkAsCompleted(Guid guid);

}
