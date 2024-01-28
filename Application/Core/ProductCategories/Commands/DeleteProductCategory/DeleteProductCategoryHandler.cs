using Domain.Repository_Interfaces;

namespace Application.Core.ProductCategories.Commands.DeleteProductCategory;
internal class DeleteProductCategoryHandler(IStoreRepository storeRepo,IProductCategoriesRepository categoryRepo) : IRequestHandler<DeleteProductCategoryCommand, ErrorOr<bool>>
{
    async Task<ErrorOr<bool>> IRequestHandler<DeleteProductCategoryCommand, ErrorOr<bool>>.Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepo.GetCategoryAsync(request.data.Id);
        if (!await storeRepo.UserAllowedToEditStoreAsync(request.userId, category.StoreId))
        {
            return Error.Unauthorized("User", "User is not allowed to edit this store");
        }
        await categoryRepo.DeleteCategoryAsync(category);
        return true;
    }
}
