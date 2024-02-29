using API.Contracts.ProductCategory;
using Application.Core.ProductCategories.Queries.GetAllCategories;
using Common.DateTimeProvider;
using Domain.Common.ProductCategories;
using Domain.Database;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.Core.ProductCategories.Commands.CreateNewProductCategory;
using Application.Core.ProductCategories.Commands.DeleteProductCategory;
using Application.Core.ProductCategories.Commands.UpdateProductCategory;
using Application.Core.ProductCategories.Queries.CategoriesWithStats;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController(ISender mediator, IHttpContextAccessor httpContextAccessor, ILogger<ProductCategoryController> logger) : ControllerBase
{

    /// <summary>
    /// Get a list of all owned categories with their stats
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<List<CategoriesWithStats>>), 200)]
    [HttpGet("CategoriesWithStats"), Authorize]
    public async Task<IActionResult> CategoriesWithStats([FromQuery]long storeId)
    {
        logger.LogInformation($"Get All Categories With Stats request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)?? 
                        throw new UnauthorizedAccessException();
        CategoriesWithStatsQuery query = new(new CategoriesWithStatsQueryDTO(storeId), long.Parse(userId ?? throw new InvalidOperationException()));
        return Ok(await mediator.Send(query));
    }


    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<List<ProductCategory>>), 200)]
    [HttpGet("GetAllCategories"), Authorize]
    public async Task<IActionResult> GetAllCategories([FromQuery]long storeId)
    {
        logger.LogInformation($"Get All Categories request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)?? 
                     throw new UnauthorizedAccessException();
        AllCategoriesQuery query = new(new AllCategoriesQueryDTO(storeId), long.Parse(userId ?? string.Empty));
        return Ok(await mediator.Send(query));
    }

    /// <summary>
    /// Create a new product category
    /// </summary>
    /// <param name="request">The details of the category </param>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<bool>), 200)]
    [HttpPost("create"), Authorize]
    public async Task<IActionResult> CreateProductCategory(CreateProductCategoryRequest request)
    {
        logger.LogInformation($"Create Product Category request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)?? 
                     throw new UnauthorizedAccessException();
        CreateNewProductCategoryCommand query = new(new CreateNewProductCategoryCommandDTO(request.Name,
                                                                                           request.Description,request.StoreId
                                                                                           ), long.Parse(userId));
        return Ok(await mediator.Send(query));
    }

    /// <summary>
    /// Delete a product category
    /// </summary>
    /// <param name="request">The details of the category </param>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<bool>), 200)]
    [HttpPost("Delete"), Authorize]
    public async Task<IActionResult> DeleteProductCategory(DeleteProductCategoryRequest request)
    {
        logger.LogInformation($"Delete Product Category request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)?? 
                     throw new UnauthorizedAccessException();
        DeleteProductCategoryCommand query = new(new(request.Id), long.Parse(userId));
        return Ok(await mediator.Send(query));
    }

    /// <summary>
    /// Edit a product category
    /// </summary>
    /// <param name="request">The details of the category </param>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorOr<ProductCategory>), 200)]
    [HttpPost("Update"), Authorize]
    public async Task<IActionResult> UpdateProductCategory(UpdateProductCategoryRequest request)
    {
        logger.LogInformation($"Update Product Category request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)?? 
                     throw new UnauthorizedAccessException();
        UpdateProductCategoryCommand query = new(new(request.Name,request.Description,request.Id), long.Parse(userId));
        return Ok(await mediator.Send(query));
    }
}
