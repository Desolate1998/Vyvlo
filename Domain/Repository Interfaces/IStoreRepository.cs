namespace Domain.Repository_Interfaces;

public interface IStoreRepository
{
    public Task<Store?> GetStoreByNameAsync (string storeName);
    public Task<Store> CreateStoreAsync (Store store);
    public Task<List<KeyValuePair<long,string>>> GetUserStoresAsync(long userId);
    public Task<bool> CheckStoreExistsAsync(string storeName);
    public Task<bool> UserAllowedToEditStoreAsync(long userId, long storeId);
}
