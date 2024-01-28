namespace Application.Core.ProductCategories.Queries.GetAllCategories;


public record AllCategoriesQuery(AllCategoriesQueryDTO Data, long UserId) : IRequest<ErrorOr<List<ProductCategory>>>;
