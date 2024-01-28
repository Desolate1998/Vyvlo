
namespace Application.Core.ProductCategories.Queries.CategoriesWithStats;

public class CategoriesWithStatsQueryValidator:AbstractValidator<CategoriesWithStatsQuery>
{
    public CategoriesWithStatsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id cannot be empty");
        RuleFor(x => x.Data.StoreId).NotEmpty().WithMessage("Store id cannot be empty");
    }
}
