namespace Domain.Database;

public  class ProductCategoryLink
{
    public long ProductId { get; init; }
    public long CategoryId { get; init; }
    public virtual Product Product { get; init; }
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
