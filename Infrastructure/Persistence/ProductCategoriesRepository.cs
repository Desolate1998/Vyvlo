using Application.Common.Repositories;
using Domain.Common.ProductCategories;
using Domain.Database;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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

    async Task<List<GetAllCategoriesWithStats>> IProductCategoriesRepository.GetProductCategoriesAsync(long userId)
    {
        return await (from productCategories in context.ProductCategories join
                stores in context.Stores on productCategories.StoreId equals stores.Id 
                where stores.OwnerId == userId join ProductCategory in context.ProductCategories 
                on productCategories.Id equals ProductCategory.Id
                join products in context.Products on ProductCategory.Id equals products.Id
                group products by new { productCategories.Id, productCategories.Name,productCategories.Description} into grouped
                select new GetAllCategoriesWithStats
                {
                    ProductCategoryId = grouped.Key.Id,
                    Name= grouped.Key.Name,
                    TotalStock= grouped.Sum(p => p.Stock),
                    Description= grouped.Key.Description,
                    TotalProducts = grouped.Count()
                }).AsNoTracking().ToListAsync();

                //SQL for incase the above query does not work as expected 
                //SELECT
                //pc.Id,
                //pc.Name,
                //pc.Description,
                //SUM(p.Stock) AS TotalStock,
                //COUNT(p.Id) AS TotalProducts
                //FROM ProductCategories pc
                //INNER JOIN Stores s ON s.id = pc.StoreId AND s.StoreOwnerId = 1
                //INNER JOIN ProductProductCategory pcc ON pcc.ProductCategoryId = pc.Id
                //INNER JOIN Products p ON p.Id = pcc.ProductsId
                //GROUP BY pc.Id, pc.Name, pc.Description;

    }
}
