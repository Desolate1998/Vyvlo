using Application.Common.Repositories;
using Common.JwtTokenGenerator;
using Domain.Database;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Core.Authentication.Commands.Register;

public class RegisterCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterCommand, ErrorOr<bool>>
{
    public async Task<ErrorOr<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExistsCheck = await userRepository.GetUserByEmailAsync(request.user.Email);
        if (userExistsCheck is not null)
        {
            return Error.Conflict("User", "User already exists");
        }

        var user = User.CreateUser(request.user.Email,
                                   request.user.Password,
                                   request.user.FirstName,
                                   request.user.FirstName);

        await userRepository.RegisterUserAsync(user);
        return true;
    }
}
