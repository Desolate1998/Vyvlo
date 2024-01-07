using ErrorOr;
using MediatR;

namespace Application.Core.Authentication.Commands.Register;

public record RegisterCommand(
    RegisterCommandRequestDTO Data
    ) : IRequest<ErrorOr<bool>>;