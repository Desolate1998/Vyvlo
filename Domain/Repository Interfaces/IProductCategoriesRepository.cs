using Domain.Common.ProductCategories;
using Domain.Database;

namespace Application.Common.Repositories;

public interface IProductCategoriesRepository
{
    public Task<List<GetAllCategoriesWithStats>> GetProductCategoriesAsync(long userId);
    public Task<bool> CheckIfProductCategoryExistsAsync(long userId, string categoryName);
    public Task CreateProductCategoryAsync(ProductCategory productCategory);
}
