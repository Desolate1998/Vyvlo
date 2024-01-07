using Application.Common.Repositories;
using Domain.Database;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class StoreRepository(DataContext database) : IStoreRepository
{
    async Task<bool> IStoreRepository.CheckStoreExistsAsync(string storeName)
    {
        return await database.Stores.Where(x => x.Name.ToUpper() == storeName.ToUpper())
                                    .AnyAsync();
    }

    async Task<Store> IStoreRepository.CreateStoreAsync(Store store)
    {
        _ = database.Stores.Add(store);
        _ = await database.SaveChangesAsync();
        return store;
    }

    async Task<Store?> IStoreRepository.GetStoreByNameAsync(string storeName)
    {
        return await database.Stores.Where(x => x.Name.ToUpper() == storeName.ToUpper())
                                    .FirstOrDefaultAsync();
    }

    async Task<List<KeyValuePair<long, string>>> IStoreRepository.GetUserStoresAsync(long userId)
    {
        return await database.Stores.Where(x => x.OwnerId == userId)
                                    .OrderByDescending(x => x.Name)
                                    .Select(x => new KeyValuePair<long, string>(x.Id, x.Name))
                                    .ToListAsync();
    }
}
