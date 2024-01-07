using Application.Core.Store.Queries.GetAllUserStores;
using ErrorOr;
using MediatR;

namespace Application.Core.Store.Queries.GetAllUserStore;

public record GetUserOwnedStoreNamesQuery(
    long UserId
):IRequest<ErrorOr<List<KeyValuePair<long,string>>>>;
