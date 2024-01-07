using Application.Common.Repositories;
using Domain.Common.ProductCategories;
using ErrorOr;
using MediatR;

namespace Application.Core.ProductCategories.Queries.GetAllCategories;

public class GetAllCategoriesWithStatsQueryHandler(IProductCategoriesRepository repo) : IRequestHandler<GetAllCategoriesWithStatsQuery, ErrorOr<List<GetAllCategoriesWithStats>>>
{
    async Task<ErrorOr<List<GetAllCategoriesWithStats>>> IRequestHandler<GetAllCategoriesWithStatsQuery, ErrorOr<List<GetAllCategoriesWithStats>>>.Handle(GetAllCategoriesWithStatsQuery request, CancellationToken cancellationToken)
    {
        return await repo.GetProductCategoriesAsync(request.UserId);
    }
}
