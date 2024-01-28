namespace Application.Core.ProductCategories.Commands.DeleteProductCategory;

public class DeleteProductValidator : AbstractValidator<DeleteProductCategoryCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.data.Id).NotEmpty().WithMessage("Category id is required");
        RuleFor(x => x.userId).NotEmpty().WithMessage("User id is required");
    }
}
