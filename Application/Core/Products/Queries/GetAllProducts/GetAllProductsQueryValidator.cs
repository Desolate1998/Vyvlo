namespace Application.Core.Products.Queries.GetAllProducts;

public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
{
    public GetAllProductsQueryValidator()
    {
        RuleFor(x => x.storeId).GreaterThan(0);
        RuleFor(x => x.userId).GreaterThan(0);
    }
}



