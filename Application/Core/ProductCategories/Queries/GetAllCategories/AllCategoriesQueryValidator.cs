namespace Application.Core.ProductCategories.Queries.GetAllCategories;

public class AllCategoriesQueryValidator : AbstractValidator<AllCategoriesQuery>
{
    public AllCategoriesQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id cannot be empty");
        RuleFor(x => x.Data.StoreId).NotEmpty().WithMessage("Store id cannot be empty");
    }
}
