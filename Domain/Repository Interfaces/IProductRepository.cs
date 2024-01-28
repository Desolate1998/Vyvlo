namespace Domain.Repository_Interfaces;

public interface IProductRepository
{
   public Task<Product> GetProductAsync(long productId);
    public Task<List<Product>> GetAllProductsAsync(long storeId);
    public Task<List<Product>> GetProductsByCategoryAsync(long categoryId);
    public Task<Product> UpdateProductAsync(Product product);
    public Task<Product> CreateProductAsync(Product product);
    public Task DeleteProductAsync(Product product);
    
    public Task<bool> CheckIfProductExistsAsync(string productName, long storeId);
}
