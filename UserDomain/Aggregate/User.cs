using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairdresserAPI.UserDomain.Enums;
using HairdresserAPI.UserDomain.Utilities;

namespace HairdresserAPI.UserDomain.Aggregate;

public class User
{
    public User(string username, string password, UserTypeEnum userType)
    {
        VerifyUsername(username);
        VerifyPassword(password);

        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        ModfiedDate = null;
        Username = username;
        Password = HashingUtility.HashPassword(password);
        UserType = userType;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; private set; }

    [Required]
    public DateTime CreatedDate { get; private set; }

    public DateTime? ModfiedDate { get; private set; }

    [Required]
    [StringLength(50)]
    public string Username { get; private set; }

    [Required]
    public string Password { get; private set; }

    [Required]
    public UserTypeEnum UserType { get; private set; }

    private static void VerifyPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or whitespace.", nameof(password));
    }

    private static void VerifyUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));
    }
}
