using System.Security.Claims;
using API.Contracts.Product;
using Application.Core.Products.Commands.CreateProduct;
using Application.Core.Products.Queries.GetAllProducts;
using Common.DateTimeProvider;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class ProductController(ISender mediator, IHttpContextAccessor httpContextAccessor, ILogger<ProductController> logger):ControllerBase
{
    [HttpPost("Create"), Authorize]
    public async Task<IActionResult> CreateProduct([FromForm]CreateNewProductRequest request, ICollection<IFormFile> images)
    {
        logger.LogInformation($"CreateProduct request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? 
                     throw new UnauthorizedAccessException();
    
        CreateProductCommand createProductCommand = new(new CreateProductCommandRequestDTO(
            request.ProductName,
            request.ProductDescription,
            request.GetCategories(),
            request.Stock,
            request.GetMetaTags(),
            decimal.Parse(request.Price, System.Globalization.CultureInfo.InvariantCulture),
            images,
            request.StoreId),long.Parse(userId)); 
        
        return Ok(await mediator.Send(createProductCommand));
    }

    [HttpGet("GetAll"), Authorize]
    public async Task<IActionResult> GetAllProducts([FromQuery] long storeId)
    {
    
        logger.LogInformation($"GetAllProducts request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ??
             throw new UnauthorizedAccessException();
        GetAllProductsQuery getAllProductsQuery = new(storeId,long.Parse(userId));
        return Ok(await mediator.Send(getAllProductsQuery));
    }
}
