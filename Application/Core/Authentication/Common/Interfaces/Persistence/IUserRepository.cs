using Domain.Database;
using ErrorOr;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    public Task<User?> GetUserByEmailAsync(string email);
    public Task<ErrorOr<bool>> RegisterUserAsync(User user);
}
