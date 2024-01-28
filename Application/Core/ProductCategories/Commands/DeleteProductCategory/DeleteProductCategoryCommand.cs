namespace Application.Core.ProductCategories.Commands.DeleteProductCategory;

public record DeleteProductCategoryCommand(DeleteProductCategoryDTO data, long userId):IRequest<ErrorOr<bool>>;

