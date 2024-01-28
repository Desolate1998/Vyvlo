using Common.JwtTokenGenerator;
using Domain.Repository_Interfaces;
using Infrastructure.Core.PasswordHelper;

namespace Application.Core.Authentication.Queries.Login;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginQuery, ErrorOr<LoginQueryResponse>>
{
    async Task<ErrorOr<LoginQueryResponse>> IRequestHandler<LoginQuery, ErrorOr<LoginQueryResponse>>.Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        User user = await userRepository.GetUserByEmailAsync(request.Data.Email);

        if (user is null) return Error.Unauthorized("Login", "Invalid login details");

        if (PasswordHelper.ValidLoginPassword(request.Data.Password, user.Salt, user.PasswordHash) == false)
        {
            return Error.Unauthorized("Login", "Invalid login details");
        }

        var token = jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return new LoginQueryResponse(token, user.FirstName, user.LastName, user.Email);
    }
}
