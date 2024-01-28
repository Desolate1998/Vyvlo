using Microsoft.AspNetCore.Http;

namespace Application.Core.Products.Commands.CreateProduct;

public record CreateProductCommandRequestDTO(string ProductName,
            string ProductDescription,
            ICollection<long> Categories,
            int Stock, 
            ICollection<string> MetaTags,
            decimal Price,
            ICollection<IFormFile> Images,
            long StoreId);