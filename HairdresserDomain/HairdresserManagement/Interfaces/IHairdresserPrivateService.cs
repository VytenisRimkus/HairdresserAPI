using HairdresserAPI.HairdresserDomain.HairdresserDtos;

namespace HairdresserAPI.HairdresserDomain.HairdresserManagement.Interfaces;

public interface IHairdresserPrivateService
{
    Task<HairdresserDto> CreateHairdresserAsync(CreateHairdresserDto dto, Guid userId);
    Task<HairdresserDto> GetHairdresserByIdAsync(Guid id);
    Task<HairdresserDto> UpdateHairdresserAsync(Guid id, UpdateHairdresserDto dto, Guid userId);
    Task DeleteHairdresserAsync(Guid id, Guid userId);
}