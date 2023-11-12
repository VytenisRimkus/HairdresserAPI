using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HairdresserAPI.Interfaces;
using HairdresserAPI.UserDomain.Aggregate;
using Microsoft.IdentityModel.Tokens;

namespace HairdresserAPI.Services;

public class AuthService : IAuthService
{
    public AuthService()
    {
    }

    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("350961871774de4291ac29822121fda333577e3bb36d2c96c1874c8cd7ac5187");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.UserType.ToString()),
        }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}