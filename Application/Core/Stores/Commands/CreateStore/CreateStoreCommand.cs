using ErrorOr;
using MediatR;

namespace Application.Core.Store.Commands.CreateStore;

public record CreateStoreCommand(
    CreateStoreCommandRequestDTO Data,long UserId) :IRequest<ErrorOr<Domain.Database.Store>>;
