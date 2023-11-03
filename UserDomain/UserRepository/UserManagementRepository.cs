using HairdresserAPI.DatabaseContext;
using HairdresserAPI.UserDomain.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAPI.UserDomain.UserRepository;

public class UserManagementRepository : IUserManagementRepository
{
    private readonly AppDbContext _context;

    public UserManagementRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> IsUsernameAvailable(string username)
    {
        var user = await _context.Users
            .Where(x => x.Username == username)
            .FirstOrDefaultAsync();

        return user == null;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
