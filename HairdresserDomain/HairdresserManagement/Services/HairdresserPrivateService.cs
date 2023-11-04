using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;
using HairdresserAPI.HairdresserDomain.HairdresserManagement.Interfaces;
using HairdresserAPI.HairdresserDomain.HairdresserRepository;
using HairdresserAPI.UserDomain.Enums;
using HairdresserAPI.UserDomain.UserRepository;

namespace HairdresserAPI.HairdresserDomain.HairdresserManagement.Services;

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
        return MapToDto(hairdresser);
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
}
