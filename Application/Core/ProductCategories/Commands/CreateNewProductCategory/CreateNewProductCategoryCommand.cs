namespace Application.Core.ProductCategories.Commands.CreateNewProductCategory;

public record CreateNewProductCategoryCommand(CreateNewProductCategoryCommandDTO Data, long UserId) :IRequest<ErrorOr<bool>>;
