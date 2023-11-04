using HairdresserAPI.UserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;

public interface IUserManagementRepository
{
    Task<bool> IsUsernameAvailable(string username);
    Task AddAsync(User user);
    Task SaveChangesAsync();
    Task<User> GetByUsername(string username);
    Task<User> GetById(Guid id);
}
