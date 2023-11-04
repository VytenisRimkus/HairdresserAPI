using HairdresserAPI.HairdresserDomain.Aggregate;

namespace HairdresserAPI.HairdresserDomain.HairdresserRepository;

public interface IHairdresserRepository
{
    Task<Hairdresser> GetByIdAsync(Guid id);
    Task<List<Hairdresser>> GetAllAsync();
    Task AddAsync(Hairdresser hairdresser);
    Task UpdateAsync(Hairdresser hairdresser);
    Task DeleteAsync(Hairdresser hairdresser);
}
