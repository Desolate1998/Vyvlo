using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Database;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Core.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RegisterCommandHandler> _logger;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public RegisterCommandHandler(IUserRepository userRepository,
                                      ILogger<RegisterCommandHandler> logger,
                                      IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _logger = logger;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public  async Task<ErrorOr<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = User.CreateUser(request.user.Email,
                                       request.user.Password,
                                       request.user.FirstName,
                                       request.user.FirstName);

            var results = await _userRepository.RegisterUserAsync(user);
            return results;
        }
    }
}
