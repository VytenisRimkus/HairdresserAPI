using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;
using HairdresserAPI.HairdresserDomain.HairdresserManagement.Interfaces;
using HairdresserAPI.HairdresserDomain.HairdresserRepository;
using HairdresserAPI.UserDomain.UserRepository;

namespace HairdresserAPI.HairdresserDomain.HairdresserManagement.Services;

public class TimeSlotPrivateService : ITimeSlotPrivateService
{
    private readonly ITimeSlotRepository _timeSlotRepository;
    private readonly IHairdresserRepository _hairdresserRepository;
    private readonly IUserManagementRepository _userManagementRepository;

    public TimeSlotPrivateService(
        ITimeSlotRepository timeSlotRepository,
        IHairdresserRepository hairdresserRepository,
        IUserManagementRepository userManagementRepository)
    {
        _timeSlotRepository = timeSlotRepository;
        _hairdresserRepository = hairdresserRepository;
        _userManagementRepository = userManagementRepository;
    }

    public async Task<TimeSlotDto> CreateTimeSlotAsync(TimeSlotCreationDto creationDto, Guid hairdresserId)
    {
        if (await _timeSlotRepository.HasOverlap(hairdresserId, creationDto.StartTime, creationDto.EndTime))
        {
            throw new Exception("Time slot overlaps with existing slot.");
        }

        var timeSlot = new TimeSlot
        {
            HairdresserId = hairdresserId,
            StartTime = creationDto.StartTime,
            EndTime = creationDto.EndTime
        };

        await _timeSlotRepository.AddTimeSlotAsync(timeSlot);

        return new TimeSlotDto
        {
            Id = timeSlot.Id,
            StartTime = timeSlot.StartTime,
            EndTime = timeSlot.EndTime
        };
    }

    public async Task<IEnumerable<TimeSlotDto>> GetTimeSlotsByHairdresserIdAsync(Guid hairdresserId)
    {
        var timeSlots = await _timeSlotRepository.GetTimeSlotsByHairdresserId(hairdresserId);
        return timeSlots.Select(ts => new TimeSlotDto
        {
            Id = ts.Id,
            StartTime = ts.StartTime,
            EndTime = ts.EndTime
        });
    }

    public async Task UpdateTimeSlotAsync(Guid id, TimeSlotUpdateDto updateDto)
    {
        var timeSlot = await _timeSlotRepository.GetTimeSlotByIdAsync(id);
        if (timeSlot == null)
        {
            throw new Exception("Time slot not found.");
        }

        if (await _timeSlotRepository.HasOverlap(timeSlot.HairdresserId, updateDto.StartTime, updateDto.EndTime))
        {
            throw new Exception("Time slot overlaps with existing slot.");
        }

        timeSlot.StartTime = updateDto.StartTime;
        timeSlot.EndTime = updateDto.EndTime;

        await _timeSlotRepository.UpdateTimeSlotAsync(timeSlot);
    }

    public async Task DeleteTimeSlotAsync(Guid id)
    {
        await _timeSlotRepository.DeleteTimeSlotAsync(id);
    }
}
