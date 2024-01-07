using Domain.Database;

namespace Application.Common.Repositories;

public interface IStoreRepository
{
    public Task<Store?> GetStoreByNameAsync (string storeName);
    public Task<Store> CreateStoreAsync (Store store);
    public Task<List<KeyValuePair<long,string>>> GetUserStoresAsync(long userId);
    public Task<bool> CheckStoreExistsAsync(string storeName);
}
