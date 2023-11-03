using HairdresserAPI.UserDomain.Aggregate;

namespace HairdresserAPI.UserDomain.UserRepository;

public interface IUserManagementRepository
{
    Task<bool> IsUsernameAvailable(string username);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}
