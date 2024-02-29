using Domain.Common.ProductCategories;

namespace Domain.Repository_Interfaces;

public interface IProductCategoriesRepository
{
    public Task<List<CategoriesWithStats>> GetProductCategoriesWithStatsAsync(long storeId);
    public Task<List<ProductCategory>> GetProductCategoriesAsync(long storeId);
    public Task<bool> CheckIfProductCategoryExistsAsync(long userId, string categoryName);
    public Task CreateProductCategoryAsync(ProductCategory productCategory);
    public Task<ProductCategory> UpdateCategoryAsync(ProductCategory productCategory);
    public Task DeleteCategoryAsync(ProductCategory productCategory);
    public Task<ProductCategory?> GetCategoryAsync(long productCategoryId);
    public Task LinkProductCategory(ICollection<ProductCategoryLink> links);

}
