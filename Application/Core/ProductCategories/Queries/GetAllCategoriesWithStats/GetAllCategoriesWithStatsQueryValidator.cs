
using FluentValidation;

namespace Application.Core.ProductCategories.Queries.GetAllCategories;

public class GetAllCategoriesWithStatsQueryValidator:AbstractValidator<GetAllCategoriesWithStatsQuery>
{
    public GetAllCategoriesWithStatsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id cannot be empty");
    }
}
