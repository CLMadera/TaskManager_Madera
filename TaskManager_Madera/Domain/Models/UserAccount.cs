using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

/// <summary>
/// Użytkownik systemu wykorzystywany do uwierzytelniania.
/// Model biznesowy i bazodanowy konta w systemie.
/// </summary>
public class UserAccount : IUser
{

    public int UserId { get; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public UserRole Role { get; private set; }
    public DateTime CreatedAt { get; }
    public string PasswordHash { get; private set; }
    public DateTime? PasswordLastChangedAt { get; private set; }

    public UserAccount(int userId, string userName, string email, UserRole role,
        DateTime createdAt, string passwordHash, DateTime? passwordLastChangedAt = null)
    {
        UserId = userId;
        UserName = userName;
        Email = email;
        Role = role;
        CreatedAt = createdAt;
        PasswordHash = passwordHash;
        PasswordLastChangedAt = passwordLastChangedAt;
    }





    public static UserAccount Create(string userName, string email, UserRole role, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(passwordHash) || !email.Contains("@"))
        {
            throw new ValidationException();
        }

        return new UserAccount(0, userName, email, role, DateTime.UtcNow, passwordHash);
    }
}