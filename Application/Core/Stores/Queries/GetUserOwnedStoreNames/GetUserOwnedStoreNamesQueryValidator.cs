namespace Application.Core.Stores.Queries.GetUserOwnedStoreNames;

public class GetUserOwnedStoreNamesQueryValidator:AbstractValidator<GetUserOwnedStoreNamesQuery>
{
    public GetUserOwnedStoreNamesQueryValidator()
    {
       RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
    }
}
