using HairdresserAPI.HairdresserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;

public interface IHairdresserRepository
{
    Task<Hairdresser> GetByIdAsync(Guid id);
    Task<List<Hairdresser>> GetAllAsync();
    Task AddAsync(Hairdresser hairdresser);
    Task UpdateAsync(Hairdresser hairdresser);
    Task DeleteAsync(Hairdresser hairdresser);
    Task<List<Hairdresser>> GetManyByIdAsync(Guid guid);

}
