using Application.Core.Store.Queries.GetAllUserStore;
using FluentValidation;

namespace Application.Core.Store.Queries.GetAllUserStores;

public class GetUserOwnedStoreNamesQueryValidator:AbstractValidator<GetUserOwnedStoreNamesQuery>
{
    public GetUserOwnedStoreNamesQueryValidator()
    {
       RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
    }
}
