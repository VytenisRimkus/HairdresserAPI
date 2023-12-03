
using HairdresserAPI.HairdresserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;
public interface IServiceBookingService
{
    Task<Service> CreateService(Service service);
    Task<Service> GetService(Guid guid);
}