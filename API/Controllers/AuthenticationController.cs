using Application.Core.Authentication.Commands.Register;
using Application.Core.Authentication.Queries.Login;
using Common.Mapper;
using Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(ILogger<AuthenticationController> logger, ISender mediator) : ControllerBase
{
    [HttpPost("Register")]
    [Produces("application/json")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        logger.LogInformation($"Registration request received at [{DateTime.UtcNow}]");

        RegisterCommand command = new(Mapper.Map<RegisterCommandRequestDTO>(request));
        var results = await mediator.Send(command);
        return Ok(results);
    }

    [HttpPost("Login")]
    [Produces("application/json")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        logger.LogInformation($"Login request received at [{DateTime.UtcNow}]");

        LoginQuery command = new(Mapper.Map<LoginQueryRequestDTO>(request));
        var results = await mediator.Send(command);
        return Ok(results);
    }
}
