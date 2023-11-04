using HairdresserAPI.HairdresserDomain.HairdresserDtos;

namespace HairdresserAPI.HairdresserDomain.HairdresserManagement.Interfaces;

public interface ITimeSlotPrivateService
{
    Task<TimeSlotDto> CreateTimeSlotAsync(TimeSlotCreationDto creationDto, Guid hairdresserId);
    Task<IEnumerable<TimeSlotDto>> GetTimeSlotsByHairdresserIdAsync(Guid hairdresserId);
    Task UpdateTimeSlotAsync(Guid id, TimeSlotUpdateDto updateDto);
    Task DeleteTimeSlotAsync(Guid id);
}