using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Database;
using ErrorOr;
using MediatR;

namespace Application.Core.Authentication.Queries.Login
{
    public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginQuery, ErrorOr<LoginQueryResponse>>
    {
        async Task<ErrorOr<LoginQueryResponse>> IRequestHandler<LoginQuery, ErrorOr<LoginQueryResponse>>.Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            User user = await userRepository.GetUserByEmailAsync(request.loginDetails.Email);
            
            if (user is null) return Error.Unauthorized("Login", "Invalid login details");

            if(user.ValidLoginPassword(request.loginDetails.Password) == false) return Error.Unauthorized("Login", "Invalid login details");

            var token = jwtTokenGenerator.GenerateToken(user.UserID, user.FirstName, user.LastName);

            return new LoginQueryResponse(token, user.FirstName, user.LastName, user.Email);
        }
    }
}
