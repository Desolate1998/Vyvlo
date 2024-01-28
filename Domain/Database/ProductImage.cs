namespace Domain.Database;

public class ProductImage
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public string ImageUrl { get; set; }
    public virtual Product Product { get; set; }
    
    public static ProductImage CreateProductImage(long productId, string imageUrl)
    {
        return new ProductImage
        {
            ProductId = productId,
            ImageUrl = imageUrl
        };
    }
    
    public static ProductImage CreateProductImage( string imageUrl)
    {
        return new ProductImage
        {
            ImageUrl = imageUrl
        };
    }
}