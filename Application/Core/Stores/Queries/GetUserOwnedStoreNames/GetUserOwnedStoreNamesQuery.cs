namespace Application.Core.Stores.Queries.GetUserOwnedStoreNames;

public record GetUserOwnedStoreNamesQuery(
    long UserId
):IRequest<ErrorOr<List<KeyValuePair<long,string>>>>;
