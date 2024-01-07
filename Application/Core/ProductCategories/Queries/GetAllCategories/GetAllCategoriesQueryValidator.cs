
using FluentValidation;

namespace Application.Core.ProductCategories.Queries.GetAllCategories;

public class GetAllCategoriesQueryValidator:AbstractValidator<GetAllCategoriesQuery>
{
    public GetAllCategoriesQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id cannot be empty");
    }
}
