namespace Application.Core.Stores.Commands.CreateStore;

public record CreateStoreCommand(
    CreateStoreCommandRequestDTO Data,long UserId) :IRequest<ErrorOr<Domain.Database.Store>>;
