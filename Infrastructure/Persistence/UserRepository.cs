using Domain.Database;
using Domain.Repository_Interfaces;
using ErrorOr;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class UserRepository(DataContext database) : IUserRepository
{
    async Task<bool> IUserRepository.CheckIfEmailIsInUseAsync(string email) => await database.Users.Where(x => x.Email == email).AnyAsync();

    async Task<User?> IUserRepository.GetUserByEmailAsync(string email) => await database.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

    async Task IUserRepository.RegisterUserAsync(User user)
    {
        database.Users.Add(user);
        await database.SaveChangesAsync();
    }
}
