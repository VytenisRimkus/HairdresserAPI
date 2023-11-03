using HairdresserAPI.UserDomain.Aggregate;
using HairdresserAPI.UserDomain.Enums;
using HairdresserAPI.UserDomain.UserDTO;
using HairdresserAPI.UserDomain.UserManagement.Interfaces;
using HairdresserAPI.UserDomain.UserRepository;
using HairdresserAPI.UserDomain.Utilities;

namespace HairdresserAPI.UserDomain.UserManagement.Services;

public class UserManagementPrivateService : IUserManagementPrivateService
{
    private readonly IUserManagementRepository _userManagementRepository;
    public UserManagementPrivateService(IUserManagementRepository userManagementRepository)
    {
        _userManagementRepository = userManagementRepository;
    }

    public async Task<User> RegisterUserAsync(RegistrationDto registrationDto)
    {
        if (!await _userManagementRepository.IsUsernameAvailable(registrationDto.Username))
            throw new Exception("Such username already exists");

        var userType = GetUserType(registrationDto);

        var user = new User(registrationDto.Username, registrationDto.Password, userType);

        await _userManagementRepository.AddAsync(user);
        await _userManagementRepository.SaveChangesAsync();

        return user;
    }

    public async Task<User> AuthenticateUserAsync(LoginDto loginDto)
    {
        var user = await _userManagementRepository.GetByUsername(loginDto.Username) ?? throw new Exception("Such username does not exist");

        var isAuthorized = HashingUtility.VerifyPassword(user.Password, loginDto.Password);

        if(isAuthorized)
            return user;
        
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
