using Application.Core.Authentication.Commands.Register;
using Application.Core.Authentication.Queries.Login;
using Common.DateTimeProvider;
using Common.Mapper;
using Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(ILogger<AuthenticationController> logger, ISender mediator) : ControllerBase
{
    [HttpPost("Register")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<bool>), 200)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        logger.LogInformation($"Registration request received at [{DateTimeProvider.ApplicationDate}]");
        RegisterCommand command = new(Mapper.Map<RegisterCommandRequestDTO>(request));
        return Ok(await mediator.Send(command));
    }

    [HttpPost("Login")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<LoginQueryResponse>), 200)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        logger.LogInformation($"Login request received at [{DateTimeProvider.ApplicationDate}]");
        LoginQuery command = new(Mapper.Map<LoginQueryRequestDTO>(request));
        return Ok(await mediator.Send(command));
    }
}
