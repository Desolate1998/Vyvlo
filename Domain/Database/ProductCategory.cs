namespace Domain.Database;

public class ProductCategory
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long StoreId { get; set; }   
    public virtual Store Store { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
