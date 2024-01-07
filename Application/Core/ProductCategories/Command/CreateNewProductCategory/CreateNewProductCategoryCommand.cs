using MediatR;
using ErrorOr;
namespace Application.Core.ProductCategories.Command.CreateNewProductCategory;

public record CreateNewProductCategoryCommand(CreateNewProductCategoryCommandDTO Data, long UserId) :IRequest<ErrorOr<bool>>;
