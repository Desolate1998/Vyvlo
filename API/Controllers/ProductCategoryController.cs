using API.Contracts.ProductCategory;
using Application.Core.ProductCategories.Command.CreateNewProductCategory;
using Application.Core.ProductCategories.Queries.GetAllCategories;
using Common.DateTimeProvider;
using Domain.Common.ProductCategories;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController(ISender mediator, IHttpContextAccessor httpContextAccessor, ILogger<ProductCategoryController> logger) : ControllerBase
{
    /// <summary>
    /// Get a list of all owned categories with their stats
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<List<GetAllCategoriesWithStats>>), 200)]
    [HttpGet("GetAllCategoriesWithStats"),Authorize]
    public async Task<IActionResult> GetAllCategoriesWithStats()
    {
        logger.LogInformation($"Get All Categories With Stats request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        GetAllCategoriesWithStatsQuery query = new(long.Parse(userId));
        return Ok(await mediator.Send(query));
    }

    /// <summary>
    /// Create a new product category
    /// </summary>
    /// <param name="request">The details of the category </param>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<bool>), 200)]
    [HttpPost("create"),Authorize]
    public async Task<IActionResult> CreateProductCategory(CreateProductCategoryRequest request)
    {
        logger.LogInformation($"Create Product Category request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        CreateNewProductCategoryCommand query = new(new CreateNewProductCategoryCommandDTO()
        {
            Description = request.Description,
            Name = request.Name,
            StoreId = request.StoreId
        },long.Parse(userId));
        return Ok(await mediator.Send(query));
    }
}
