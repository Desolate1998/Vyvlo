using Domain.Repository_Interfaces;

namespace Application.Core.Products.Queries.GetAllProducts;

public record GetAllProductsQuery(long storeId,long userId):IRequest<ErrorOr<ICollection<Product>>>;


public class GetAllProductsQueryHandler(IProductRepository productRepository, IStoreRepository storeRepository) : IRequestHandler<GetAllProductsQuery, ErrorOr<ICollection<Product>>>
{
    async Task<ErrorOr<ICollection<Product>>> IRequestHandler<GetAllProductsQuery, ErrorOr<ICollection<Product>>>.Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        if (!await storeRepository.UserAllowedToEditStoreAsync(request.userId,request.storeId))
        {
            return Error.Unauthorized("User not allowed to edit store");
        }

       return await productRepository.GetAllProductsAsync(request.storeId);
    }
}
