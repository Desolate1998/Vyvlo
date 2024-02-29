using System.Text.Json.Serialization;

namespace Domain.Database;

public  class ProductCategoryLink
{
    public long ProductId { get; init; }
    public long CategoryId { get; init; }

    [JsonIgnore]
    public virtual Product Product { get; init; }
    [JsonIgnore]
    public virtual ProductCategory Category { get; init; }
    

    public static ProductCategoryLink CreateProductCategoryLink(long productId, long categoryId)
    {
        return new ProductCategoryLink
        {
            ProductId = productId,
            CategoryId = categoryId
        };
    }
}
