namespace Application.Core.ProductCategories.Queries.CategoriesWithStats;

public record CategoriesWithStatsQuery(CategoriesWithStatsQueryDTO Data, long UserId):IRequest<ErrorOr<List<Domain.Common.ProductCategories.CategoriesWithStats>>>;
