using HairdresserAPI.Domains.HairdresserDomain.DTO;
using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;
using HairdresserAPI.Interfaces;
using HairdresserAPI.UserDomain.Enums;

namespace HairdresserAPI.Services;

public class HairdresserPrivateService : IHairdresserPrivateService
{
    private readonly IHairdresserRepository _hairdresserRepository;
    private readonly IUserManagementRepository _userManagementRepository;

    public HairdresserPrivateService(IHairdresserRepository hairdresserRepository, IUserManagementRepository userManagementRepository)
    {
        _hairdresserRepository = hairdresserRepository;
        _userManagementRepository = userManagementRepository;
    }

    public async Task<HairdresserDto> CreateHairdresserAsync(CreateHairdresserDto dto, Guid userId)
    {
        var user = await _userManagementRepository.GetById(userId);

        if (user.UserType == UserTypeEnum.Hairdresser && user != null)
        {
            var hairdresser = new Hairdresser(dto.Name, dto.Biography, dto.Location, dto.PhoneNumber, dto.Email, userId);
            await _hairdresserRepository.AddAsync(hairdresser);
            return MapToDto(hairdresser);
        }

        throw new Exception("You are not eligible to add hairdressers");
    }

    public async Task<HairdresserDto> GetHairdresserByIdAsync(Guid id)
    {
        var hairdresser = await _hairdresserRepository.GetByIdAsync(id);
        if (hairdresser == null)
        {
            throw new Exception("Hairdresser not found.");
        }
        return MapToDtoWithTimeSlots(hairdresser);
    }

    public async Task<HairdresserDto> UpdateHairdresserAsync(Guid id, UpdateHairdresserDto dto, Guid userId)
    {
        var hairdresser = await _hairdresserRepository.GetByIdAsync(id);
        if (hairdresser == null || hairdresser.CreatedByUserId == userId)
        {
            throw new Exception("Hairdresser not found.");
        }

        hairdresser.Name = dto.Name;
        hairdresser.Biography = dto.Biography;
        hairdresser.Location = dto.Location;
        hairdresser.PhoneNumber = dto.PhoneNumber;
        hairdresser.Email = dto.Email;
        await _hairdresserRepository.UpdateAsync(hairdresser);

        return MapToDto(hairdresser);
    }
    public async Task<List<Hairdresser>> GetHairdresserListByIdAsync(Guid guid)
    {
        var hairdressers = await _hairdresserRepository.GetManyByIdAsync(guid);

        return hairdressers;
    }

    public async Task<List<Hairdresser>> GetHairdresserListAsync()
    {
        var hairdressers = await _hairdresserRepository.GetManyAsync();

        return hairdressers;
    }

    public async Task DeleteHairdresserAsync(Guid id, Guid userId)
    {
        var hairdresser = await _hairdresserRepository.GetByIdAsync(id);
        if (hairdresser == null || hairdresser.CreatedByUserId == userId)
        {
            throw new Exception("Hairdresser not found.");
        }

        await _hairdresserRepository.DeleteAsync(hairdresser);
    }

    private static HairdresserDto MapToDto(Hairdresser hairdresser)
    {
        return new HairdresserDto
        {
            Name = hairdresser.Name,
            Biography = hairdresser.Biography,
            Location = hairdresser.Location,
            PhoneNumber = hairdresser.PhoneNumber,
            Email = hairdresser.Email
        };
    }

    private static HairdresserDto MapToDtoWithTimeSlots(Hairdresser hairdresser)
    {
        var timeSlotDtos = hairdresser.AvailableTimeSlots
            .Select(ts => new TimeSlotDto
            {
                Id = ts.Id,
                StartTime = ts.StartTime,
                EndTime = ts.EndTime,
                IsBooked = ts.IsBooked
            }).ToList();

         var bookings = hairdresser.Bookings
            .Select(ts => new BookingDto
            {
                Id = ts.Id.ToString(),
                UserId = ts.UserId.ToString(),
                HairdresserId = ts.HairdresserId.ToString(),
                AppointmentDate = ts.AppointmentDate,
                IsCompleted = ts.IsCompleted
            }).ToList();

        return new HairdresserDto
        {
            Name = hairdresser.Name,
            Biography = hairdresser.Biography,
            Location = hairdresser.Location,
            PhoneNumber = hairdresser.PhoneNumber,
            Email = hairdresser.Email,
            TimeSlots = timeSlotDtos,
            Bookings = bookings
        };
    }
}
