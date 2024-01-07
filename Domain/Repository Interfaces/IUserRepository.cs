using Domain.Database;

namespace Application.Common.Repositories;

public interface IUserRepository
{
    public Task<bool> CheckIfEmailIsInUseAsync(string email);
    public Task<User> GetUserByEmailAsync(string email);
    public Task RegisterUserAsync(User user);
}
