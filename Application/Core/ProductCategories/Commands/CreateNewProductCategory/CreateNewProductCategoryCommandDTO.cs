namespace Application.Core.ProductCategories.Commands.CreateNewProductCategory;
public record CreateNewProductCategoryCommandDTO(
    string Name,
    string Description,
    long StoreId
    );
