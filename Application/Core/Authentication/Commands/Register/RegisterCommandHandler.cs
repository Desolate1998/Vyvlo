﻿using Common.JwtTokenGenerator;
using Domain.Repository_Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Core.Authentication.Commands.Register;

public class RegisterCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterCommand, ErrorOr<bool>>
{
    public async Task<ErrorOr<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExistsCheck = await userRepository.GetUserByEmailAsync(request.Data.Email);
        if (userExistsCheck is not null)
        {
            return Error.Conflict("User", "User already exists");
        }

        var user = User.CreateUser(request.Data.Email,
                                   request.Data.Password,
                                   request.Data.FirstName,
                                   request.Data.FirstName);

        await userRepository.RegisterUserAsync(user);
        return true;
    }
}
