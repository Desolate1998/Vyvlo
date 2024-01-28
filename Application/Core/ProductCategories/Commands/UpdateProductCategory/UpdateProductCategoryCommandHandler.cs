using Domain.Repository_Interfaces;

namespace Application.Core.ProductCategories.Commands.UpdateProductCategory;

internal class UpdateProductCategoryCommandHandler(IProductCategoriesRepository categoryRepo, IStoreRepository storeRepo) : IRequestHandler<UpdateProductCategoryCommand, ErrorOr<ProductCategory>>
{
    async Task<ErrorOr<ProductCategory>> IRequestHandler<UpdateProductCategoryCommand, ErrorOr<ProductCategory>>.Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepo.GetCategoryAsync(request.data.categoryId);

        if (category is null)
        {
            return Error.NotFound("Category", "Category not found");
        }

        if (!await storeRepo.UserAllowedToEditStoreAsync(request.userId, category.StoreId))
        {
            return Error.Unauthorized("User", "User is not allowed to edit this store");
        }

        category.Update(request.data.name, request.data.description);
        return await categoryRepo.UpdateCategoryAsync(category);
    }
}
