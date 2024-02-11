using System.Security.Claims;
using API.Contracts.Product;
using Application.Core.Products.Commands.CreateProduct;
using Common.DateTimeProvider;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class ProductController(ISender mediator, IHttpContextAccessor httpContextAccessor, ILogger<ProductController> logger):ControllerBase
{
    [HttpPost("create"), Authorize]
    public async Task<IActionResult> CreateProduct([FromForm]IFormFile test)
    {

        CreateNewProductRequest request = new();
        logger.LogInformation($"CreateProduct request received at [{DateTimeProvider.ApplicationDate}]");
        var userId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? 
                     throw new UnauthorizedAccessException();
    
        CreateProductCommand createProductCommand = new CreateProductCommand(new CreateProductCommandRequestDTO(
            request.ProductName,
            request.ProductDescription,
            request.Categories,
            request.Stock,
            request.MetaTags,
            request.Price,
            request.Images,
            request.StoreId),long.Parse(userId)); 
        
        return Ok(await mediator.Send(createProductCommand));
    }
}
