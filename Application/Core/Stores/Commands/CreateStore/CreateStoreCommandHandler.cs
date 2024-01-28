using Domain.Repository_Interfaces;

namespace Application.Core.Stores.Commands.CreateStore;

public class CreateStoreCommandHandler(IStoreRepository storeRepository) : IRequestHandler<CreateStoreCommand, ErrorOr<Domain.Database.Store>>
{
    async Task<ErrorOr<Domain.Database.Store>> IRequestHandler<CreateStoreCommand, ErrorOr<Domain.Database.Store>>.Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        if (await storeRepository.CheckStoreExistsAsync(request.Data.Name))
        {
            return Error.Conflict("storeName", "Store already exists");
        }
        var store  = Domain.Database.Store.CreateStore(request.UserId, request.Data.Name, request.Data.Description);
        return await storeRepository.CreateStoreAsync(store);
    }
}
