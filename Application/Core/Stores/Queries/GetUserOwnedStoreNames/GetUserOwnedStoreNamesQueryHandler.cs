using Domain.Repository_Interfaces;

namespace Application.Core.Stores.Queries.GetUserOwnedStoreNames;

public class GetUserOwnedStoreNamesQueryHandler(IStoreRepository storeRepository) : IRequestHandler<GetUserOwnedStoreNamesQuery, ErrorOr<List<KeyValuePair<long, string>>>>
{
    async Task<ErrorOr<List<KeyValuePair<long, string>>>> IRequestHandler<GetUserOwnedStoreNamesQuery, ErrorOr<List<KeyValuePair<long, string>>>>.Handle(GetUserOwnedStoreNamesQuery request, CancellationToken cancellationToken)
    {
        return await storeRepository.GetUserStoresAsync(request.UserId);
    }
}
