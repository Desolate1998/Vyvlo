using Domain.Common.ProductCategories;
using Domain.Database;
using Domain.Repository_Interfaces;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class ProductCategoriesRepository(DataContext context) : IProductCategoriesRepository
{
    async Task<bool> IProductCategoriesRepository.CheckIfProductCategoryExistsAsync(long userId, string categoryName)
    {
        return await context.ProductCategories.Where(x => x.Name.ToUpper() == categoryName.ToUpper() && x.Store.OwnerId == userId)
                                              .AnyAsync();
    }

    async Task IProductCategoriesRepository.CreateProductCategoryAsync(ProductCategory productCategory)
    {
        context.ProductCategories.Add(productCategory);
        await context.SaveChangesAsync();
    }

    async Task<List<CategoriesWithStats>> IProductCategoriesRepository.GetProductCategoriesWithStatsAsync(long storeId)
    {
        return await (from category in context.ProductCategories
                      join categoryLink in context.ProductCategoryLinks on category.Id equals categoryLink.CategoryId into categoryLinks
                      from categoryLink in categoryLinks.DefaultIfEmpty()
                      join product in context.Products on categoryLink.ProductId equals product.Id into products
                      from product in products.DefaultIfEmpty()
                      where category.StoreId == storeId
                      group new { category, categoryLink, product } by new { category.Id, category.Name, category.Description } into groupedData
                      select new CategoriesWithStats
                      {
                          ProductCategoryId = groupedData.Key.Id,
                          Name = groupedData.Key.Name,
                          Description = groupedData.Key.Description,
                          TotalProducts = groupedData.Count(x=>x.product.Name !=null),
                          TotalStock = groupedData.Sum(x => x.product.Stock)
                      }).ToListAsync();
    }

    async Task IProductCategoriesRepository.DeleteCategoryAsync(ProductCategory productCategory)
    {
        await context.ProductCategoryLinks.Where(x => x.CategoryId == productCategory.Id).ExecuteDeleteAsync();
        context.ProductCategories.Remove(productCategory);
        await context.SaveChangesAsync();
    }

    async Task<ProductCategory> IProductCategoriesRepository.UpdateCategoryAsync(ProductCategory productCategory)
    {
        context.ProductCategories.Update(productCategory);
        await context.SaveChangesAsync();
        return productCategory;
    }

   async Task<ProductCategory?> IProductCategoriesRepository.GetCategoryAsync(long productCategoryId)
   {
        return await context.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryId);    
   }

    async Task<List<ProductCategory>> IProductCategoriesRepository.GetProductCategoriesAsync(long storeId)
    {
        return await context.ProductCategories.Where(x => x.StoreId == storeId).ToListAsync();
    }

    async Task IProductCategoriesRepository.LinkProductCategory(ICollection<ProductCategoryLink> links)
    {
        await context.ProductCategoryLinks.AddRangeAsync(links);
    }
}
