using HairdresserAPI.HairdresserDomain.DTO;

namespace HairdresserAPI.Interfaces;

public interface IServiceService
{
    Task AddService(ServiceDto service);
}