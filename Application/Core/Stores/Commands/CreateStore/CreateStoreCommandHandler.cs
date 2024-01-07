using Application.Common.Repositories;
using ErrorOr;
using MediatR;


namespace Application.Core.Store.Commands.CreateStore;

public class CreateStoreCommandHandler(IStoreRepository storeRepository) : IRequestHandler<CreateStoreCommand, ErrorOr<Domain.Database.Store>>
{
    async Task<ErrorOr<Domain.Database.Store>> IRequestHandler<CreateStoreCommand, ErrorOr<Domain.Database.Store>>.Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        if (await storeRepository.CheckStoreExistsAsync(request.store.Name))
        {
            return Error.Conflict("storeName", "Store already exists");
        }
        var store  = Domain.Database.Store.CreateStore(request.store.OwnerId, request.store.Name, request.store.Description);
        return await storeRepository.CreateStoreAsync(store);
    }
}
