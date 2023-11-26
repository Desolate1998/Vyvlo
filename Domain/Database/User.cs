using Common.DateTimeProvider;
using System.Security.Cryptography;

namespace Domain.Database;

public class User
{
    private User(string email,
                 string password,
                 string firstName,
                 string lastName,
                 string salt)
    {
        Email = email;
        PasswordHash = password;
        FirstName = firstName;
        LastName = lastName;
        Salt = salt;
        UpdatedAt = DateTimeProvider.ApplicationDate;
        CreatedAt = DateTimeProvider.ApplicationDate;
           
    }

    public User()
    {
            
    }

    public long UserID { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Salt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static User CreateUser(string email, string password, string firstName, string lastName)
    {
        var salt = GenerateSalt();
        return new(email, HashPassword(password, salt), firstName, lastName, Convert.ToBase64String(salt));
    }

    static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    public bool ValidLoginPassword(string password) => HashPassword(password, Convert.FromBase64String(Salt)) == PasswordHash;

    static string HashPassword(string password, byte[] salt)
    {
        using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes for a 256-bit key
            return Convert.ToBase64String(hash);
        }
    }
}
