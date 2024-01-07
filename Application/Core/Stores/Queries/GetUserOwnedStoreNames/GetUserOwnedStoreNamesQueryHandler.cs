using Application.Common.Repositories;
using Application.Core.Store.Queries.GetAllUserStore;
using ErrorOr;
using MediatR;

namespace Application.Core.Store.Queries.GetAllUserStores;

public class GetUserOwnedStoreNamesQueryHandler(IStoreRepository storeRepository) : IRequestHandler<GetUserOwnedStoreNamesQuery, ErrorOr<List<KeyValuePair<long, string>>>>
{
    async Task<ErrorOr<List<KeyValuePair<long, string>>>> IRequestHandler<GetUserOwnedStoreNamesQuery, ErrorOr<List<KeyValuePair<long, string>>>>.Handle(GetUserOwnedStoreNamesQuery request, CancellationToken cancellationToken)
    {
        return await storeRepository.GetUserStoresAsync(request.UserId);
    }
}
