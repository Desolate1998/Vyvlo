using API.Contracts.Store;
using Common.DateTimeProvider;
using Domain.Database;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.Core.Stores.Commands.CreateStore;
using Application.Core.Stores.Queries.GetUserOwnedStoreNames;


namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController(IMediator mediator, IHttpContextAccessor httpContextAccessor, ILogger<StoreController> logger) : ControllerBase
{
    [HttpPost("create"), Authorize]
    [ProducesResponseType(typeof(ErrorOr<Store>), 200)]
    public async Task<IActionResult> CreateStore([FromForm] CreateStoreRequest store)
    {
        logger.LogInformation($"CreateStore request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? 
                     throw new UnauthorizedAccessException();
        
        var command = new CreateStoreCommand(new CreateStoreCommandRequestDTO(store.Name,store.Description,store.Currency,store.Location,store.StoreImage), long.Parse(userId));

        return Ok(await mediator.Send(command));
    }

    [HttpGet("GetUserOwnedStoreNames"), Authorize]
    [ProducesResponseType(typeof(ErrorOr<List<KeyValuePair<long, string>>>), 200)]
    public async Task<IActionResult> GetUserOwnedStoreNames()    
    {
        logger.LogInformation($"GetUserOwnedStoreNames request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? 
                     throw new UnauthorizedAccessException();
        GetUserOwnedStoreNamesQuery query = new(long.Parse(userId));
        return Ok(await mediator.Send(query));
    }
}
