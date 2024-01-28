using Domain.Repository_Interfaces;

namespace Application.Core.ProductCategories.Queries.GetAllCategories;

public class AllCategoriesQueryHandler(IProductCategoriesRepository productCategoryRepo) : IRequestHandler<AllCategoriesQuery, ErrorOr<List<ProductCategory>>>
{
    async Task<ErrorOr<List<ProductCategory>>> IRequestHandler<AllCategoriesQuery, ErrorOr<List<ProductCategory>>>.Handle(AllCategoriesQuery request, CancellationToken cancellationToken)
    {
        //Due to the fact that categories can be viewed by anyone, we don't need to check
        //if the user is allowed to edit the store
        return await productCategoryRepo.GetProductCategoriesAsync(request.Data.StoreId);
    }
}