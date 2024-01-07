using Domain.Common.ProductCategories;
using ErrorOr;
using MediatR;

namespace Application.Core.ProductCategories.Queries.GetAllCategories;

public record GetAllCategoriesWithStatsQuery(long UserId):IRequest<ErrorOr<List<GetAllCategoriesWithStats>>>;
