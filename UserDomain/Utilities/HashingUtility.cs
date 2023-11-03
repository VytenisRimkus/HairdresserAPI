using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace HairdresserAPI.UserDomain.Utilities;

public class HashingUtility
{
    public HashingUtility()
    {
    }

    public static string HashPassword(string password, byte[]? salt = null)
    {
        if (salt == null || salt.Length != 16)
        {
            salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
        }

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return $"{Convert.ToBase64String(salt)}.{hashed}";
    }

    public static bool VerifyPassword(string hashedPasswordWithSalt, string passwordToVerify)
    {
        var parts = hashedPasswordWithSalt.Split('.');
        var salt = Convert.FromBase64String(parts[0]);
        var storedPassword = parts[1];

        var hashOfInputPassword = HashPassword(passwordToVerify, salt).Split('.')[1];

        return storedPassword == hashOfInputPassword;
    }
}
