namespace Application.Core.Products.Commands.CreateProduct;

internal class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Data.ProductName).NotEmpty().WithMessage("Product name is required");
        RuleFor(x => x.Data.ProductDescription).NotEmpty().WithMessage("Product description is required");
        RuleFor(x => x.Data.Categories).NotEmpty().WithMessage("Product categories are required");
        RuleFor(x => x.Data.MetaTags).NotEmpty().WithMessage("Product meta tags are required");
        RuleFor(x => x.Data.Price).NotEmpty().WithMessage("Product price is required");
        RuleFor(x => x.Data.Stock).NotEmpty().WithMessage("Product stock is required");
        RuleFor(x => x.Data.Images).NotEmpty().WithMessage("Product images are required");
        RuleFor(x => x.Data.StoreId).NotEmpty().WithMessage("Store id is required");
        RuleFor(x => x.Data.Images).Must(x => x.Count <= 5).WithMessage("Maximum 5 images allowed");
    }
}