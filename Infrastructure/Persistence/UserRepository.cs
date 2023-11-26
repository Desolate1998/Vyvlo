
using Application.Common.Interfaces.Persistence;
using Domain.Database;
using ErrorOr;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class UserRepository : IUserRepository
{
    private readonly DataContext _database;

    public UserRepository(DataContext database)
    {
        _database = database;
    }

    async Task<User?> IUserRepository.GetUserByEmailAsync(string email) => await _database.Users.FirstOrDefaultAsync(x => x.Email == email);


    async Task<ErrorOr<bool>> IUserRepository.RegisterUserAsync(User user)
    {
        var userExits = await _database.Users.Where(x => x.Email == user.Email).AnyAsync();
        if (userExits)
        {
            return Error.Conflict("User", "User already exists");
        }
        _database.Users.Add(user);
        await _database.SaveChangesAsync();
        return true;
    }
}
