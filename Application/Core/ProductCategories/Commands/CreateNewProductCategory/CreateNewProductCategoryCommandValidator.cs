namespace Application.Core.ProductCategories.Commands.CreateNewProductCategory;

public class CreateNewProductCategoryCommandValidator : AbstractValidator<CreateNewProductCategoryCommand>
{
    public CreateNewProductCategoryCommandValidator()
    {
        RuleFor(x => x.Data.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Data.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id cannot be empty");
    }
}
