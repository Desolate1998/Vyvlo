using Common.DateTimeProvider;
using System.Security.Cryptography;
using Infrastructure.Core.PasswordHelper;

namespace Domain.Database;

public sealed class User
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

    public long Id { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Salt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public ICollection<Store> Stores { get;init;  }

    public static User CreateUser(string email, string password, string firstName, string lastName)
    {
        var salt = PasswordHelper.GenerateSalt();
        return new User(email, PasswordHelper.HashPassword(password, salt), firstName, lastName, Convert.ToBase64String(salt));
    }

}
