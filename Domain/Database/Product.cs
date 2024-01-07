namespace Domain.Database;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long StoreId { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    public virtual ICollection<ProductMetaTag> ProductMetaTags { get; set; }
    public virtual Store Store { get; set; }
}
