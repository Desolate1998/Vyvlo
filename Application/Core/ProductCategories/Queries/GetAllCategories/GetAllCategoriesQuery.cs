using ErrorOr;
using MediatR;

namespace Application.Core.ProductCategories.Queries.GetAllCategories;

public record GetAllCategoriesQuery(long UserId):IRequest<ErrorOr<GetAllCategoriesQueryResponse>>;
