namespace Application.Core.ProductCategories.Commands.UpdateProductCategory;

public record UpdateProductCategoryCommand(UpdateProductCategoryDTO data, long userId):IRequest<ErrorOr<ProductCategory>>;
