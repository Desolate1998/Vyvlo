using Domain.Database;
using Domain.Repository_Interfaces;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class ProductRepository(DataContext context) : IProductRepository
{
    async Task<Product> IProductRepository.CreateProductAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    async Task IProductRepository.DeleteProductAsync(Product product)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    async Task<bool> IProductRepository.CheckIfProductExistsAsync(string productName, long storeId)
    {
        return await context.Products.AnyAsync(x=>x.StoreId== storeId && x.Name.ToUpper() == productName.ToUpper());
    }

    async Task<List<Product>> IProductRepository.GetAllProductsAsync(long storeId)
    {
        return await context.Products.Where(x => x.StoreId == storeId).ToListAsync();
    }

    async Task<Product?> IProductRepository.GetProductAsync(long productId)
    {
        return await context.Products.FirstOrDefaultAsync(x => x.Id == productId);
    }

    async Task<List<Product>> IProductRepository.GetProductsByCategoryAsync(long categoryId)
    {
        throw new NotImplementedException();
    }

    async Task<Product> IProductRepository.UpdateProductAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
        return product;
    }
}
