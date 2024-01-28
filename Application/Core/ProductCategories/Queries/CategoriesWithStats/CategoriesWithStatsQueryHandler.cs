using Domain.Repository_Interfaces;

namespace Application.Core.ProductCategories.Queries.CategoriesWithStats;

public class CategoriesWithStatsQueryHandler(IProductCategoriesRepository productCategoryRepo,IStoreRepository storeRepo) : IRequestHandler<CategoriesWithStatsQuery, ErrorOr<List<Domain.Common.ProductCategories.CategoriesWithStats>>>
{
    async Task<ErrorOr<List<Domain.Common.ProductCategories.CategoriesWithStats>>> IRequestHandler<CategoriesWithStatsQuery, ErrorOr<List<Domain.Common.ProductCategories.CategoriesWithStats>>>.Handle(CategoriesWithStatsQuery request, CancellationToken cancellationToken)
    {
        if(!await storeRepo.UserAllowedToEditStoreAsync(request.UserId, request.Data.StoreId))
        {
            return Error.Unauthorized("User", "User not allowed to edit this store");
        }
        return await productCategoryRepo.GetProductCategoriesWithStatsAsync(request.Data.StoreId);
    }
}
