using HairdresserAPI.Interfaces;
using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.Enums;
using HairdresserAPI.UserDomain.UserDTO;
using HairdresserAPI.Utilities;

namespace HairdresserAPI.Services;

public class UserManagementPrivateService : IUserManagementPrivateService
{
    private readonly IUserManagementRepository _userManagementRepository;
    private readonly IUserMappingService _userMappingService;
    public UserManagementPrivateService(IUserManagementRepository userManagementRepository, IUserMappingService userMappingService)
    {
        _userManagementRepository = userManagementRepository;
        _userMappingService = userMappingService;
    }

    public async Task<UserResponseDTO> RegisterUserAsync(RegistrationDto registrationDto)
    {
        if (!await _userManagementRepository.IsUsernameAvailable(registrationDto.Username))
            throw new Exception("Such username already exists");

        var userType = GetUserType(registrationDto);

        var user = new User(registrationDto.Username, registrationDto.Password, userType);

        await _userManagementRepository.AddAsync(user);
        await _userManagementRepository.SaveChangesAsync();

        return _userMappingService.MapUserResponseDto(user);
    }

    public async Task<UserResponseDTO> AuthenticateUserAsync(LoginDto loginDto)
    {
        var user = await _userManagementRepository.GetByUsername(loginDto.Username) ?? throw new Exception("Such username does not exist");

        var isAuthorized = HashingUtility.VerifyPassword(user.Password, loginDto.Password);

        if (isAuthorized)
        {
            var userDto = _userMappingService.MapUserResponseDto(user);
            return userDto;
        }

        throw new Exception("Password is incorrect");
    }

    private static UserTypeEnum GetUserType(RegistrationDto registrationDto)
    {
        UserTypeEnum userType;
        if (Enum.TryParse(registrationDto.UserType, true, out userType))
        {
            return userType;
        }
        else
        {
            throw new Exception("Bad user type");
        }
    }
}
