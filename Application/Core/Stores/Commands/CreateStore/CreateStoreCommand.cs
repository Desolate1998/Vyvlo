using ErrorOr;
using MediatR;

namespace Application.Core.Store.Commands.CreateStore;

public record CreateStoreCommand(
    CreateStoreCommandRequestDTO store) :IRequest<ErrorOr<Domain.Database.Store>>;
