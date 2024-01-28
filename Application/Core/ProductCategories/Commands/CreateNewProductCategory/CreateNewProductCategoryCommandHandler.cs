using Domain.Repository_Interfaces;

namespace Application.Core.ProductCategories.Commands.CreateNewProductCategory;

public class CreateNewProductCategoryCommandHandler(IProductCategoriesRepository categoryRepo, IStoreRepository storeRepo) : IRequestHandler<CreateNewProductCategoryCommand, ErrorOr<bool>>
{
    async Task<ErrorOr<bool>> IRequestHandler<CreateNewProductCategoryCommand, ErrorOr<bool>>.Handle(CreateNewProductCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await categoryRepo.CheckIfProductCategoryExistsAsync( request.UserId, request.Data.Name))
        {
            return Error.Conflict("ProductCategory", "Product Category already exists for this store");
        }

        if(!await storeRepo.UserAllowedToEditStoreAsync(request.UserId, request.Data.StoreId))
        {
            return Error.Unauthorized("User", "User not allowed to edit this store");
        }

        var productCategory = ProductCategory.CreateProductCategory(request.Data.Name, request.Data.Description, request.Data.StoreId);
        await categoryRepo.CreateProductCategoryAsync(productCategory);
        return true;
    }
}
