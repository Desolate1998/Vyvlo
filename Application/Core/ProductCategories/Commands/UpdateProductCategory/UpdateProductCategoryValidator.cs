namespace Application.Core.ProductCategories.Commands.UpdateProductCategory;

internal class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryValidator()
    {
        RuleFor(x => x.data.name).NotEmpty().WithMessage("Category name is required");
        RuleFor(x => x.data.description).NotEmpty().WithMessage("Category description is required");
        RuleFor(x => x.userId).NotEmpty().WithMessage("User id is required");
        RuleFor(x => x.data.categoryId).NotEmpty().WithMessage("Category id is required");
    }
}
