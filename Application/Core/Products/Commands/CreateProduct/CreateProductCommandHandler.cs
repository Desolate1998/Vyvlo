using Domain.Common.Interfaces;
using Domain.Common.Settings;
using Domain.Repository_Interfaces;
using Microsoft.Extensions.Options;

namespace Application.Core.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler(IFileHandler fileHandler,IOptions<FileDirectorySettings> fileSettings, IProductRepository productRepository,IStoreRepository storeRepository):IRequestHandler<CreateProductCommand, ErrorOr<Product>>
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
                request.Data.Price,
                request.Data.MetaTags,
                request.Data.Categories);
            
            foreach (var image in request.Data.Images)
            {
                var path = fileHandler.BuildPath(fileSettings.Value.Root, image.Name);
                await fileHandler.UploadFileAsync(image, path);
                product.ProductImages.Add(ProductImage.CreateProductImage(path));
            }

            await productRepository.CreateProductAsync(product);
            return product;
        }
    }
}
