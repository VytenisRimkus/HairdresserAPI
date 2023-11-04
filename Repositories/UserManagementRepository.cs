using HairdresserAPI.DatabaseContext;
using HairdresserAPI.Interfaces;
using HairdresserAPI.UserDomain.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace HairdresserAPI.Repositories;

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

    public async Task<User> GetByUsername(string username)
    {
        var user = await _context.Users
            .Where(x => x.Username == username)
            .FirstOrDefaultAsync();

        return user;
    }

    public async Task<User> GetById(Guid id)
    {
        var user = await _context.Users
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        return user;
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
