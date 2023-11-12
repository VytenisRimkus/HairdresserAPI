using HairdresserAPI.UserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;

public interface IAuthService
{
    string GenerateJwtToken(User user);
}
