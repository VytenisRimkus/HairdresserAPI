using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;

namespace HairdresserAPI.Interfaces;

public interface IHairdresserPrivateService
{
    Task<HairdresserDto> CreateHairdresserAsync(CreateHairdresserDto dto, Guid userId);
    Task<HairdresserDto> GetHairdresserByIdAsync(Guid id);
    Task<HairdresserDto> UpdateHairdresserAsync(Guid id, UpdateHairdresserDto dto);
    Task DeleteHairdresserAsync(Guid id, Guid userId);
    Task<List<Hairdresser>> GetHairdresserListByIdAsync(Guid guid);
    Task<List<Hairdresser>> GetHairdresserListAsync();
}