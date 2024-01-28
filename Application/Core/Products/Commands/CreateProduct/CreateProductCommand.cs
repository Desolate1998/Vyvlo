namespace Application.Core.Products.Commands.CreateProduct;

public record CreateProductCommand(CreateProductCommandRequestDTO Data, long UserId) : IRequest<ErrorOr<Product>>;