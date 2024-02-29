using Domain.Common.Interfaces;
using Domain.Common.Settings;
using Domain.Repository_Interfaces;
using Microsoft.Extensions.Options;

namespace Application.Core.Products.Commands.CreateProduct;

internal class CreateProductCommandHandler(IFileHandler fileHandler,
    IProductRepository productRepository,
    IStoreRepository storeRepository,
    IProductCategoriesRepository productCategoriesRepository,
    IMetaTagRepository metaTagRepository
    ):IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    async Task<ErrorOr<Product>> IRequestHandler<CreateProductCommand, ErrorOr<Product>>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (!await storeRepository.UserAllowedToEditStoreAsync(request.UserId,request.Data.StoreId))
        {
            return Error.Unauthorized();
        }
        
        if(await productRepository.CheckIfProductExistsAsync(request.Data.ProductName,request.Data.StoreId))
        {
            return Error.Conflict("Product already exists");
        }

        var product = Product.CreateProduct(
            request.Data.ProductName,
            request.Data.StoreId,
            request.Data.ProductDescription,
            request.Data.Stock,
            request.Data.Price);

        await fileHandler.UploadMultpleFileAsync(request.Data.Images,request.Data.StoreId,1);

        product = await productRepository.CreateProductAsync(product);

        await productCategoriesRepository.LinkProductCategory(request.Data.Categories.Select(x => ProductCategoryLink.CreateProductCategoryLink(product.Id, x)).ToList());
        
        await metaTagRepository.AddMetaTags(request.Data.MetaTags.Select(x => ProductMetaTag.CreateProductMetaTag(x, product.Id)).ToList());

        return product;
    }
}
