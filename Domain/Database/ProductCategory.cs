using System.Text.Json.Serialization;

namespace Domain.Database;

public class ProductCategory
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long StoreId { get; set; }

    public virtual Store Store { get; set; }

    public virtual ICollection<ProductCategoryLink> ProductCategoryLinks { get; set; }
    
    public static ProductCategory CreateProductCategory(string name, string description, long storeId)
    {
        return new()
        {
            Name = name,
            Description = description,
            StoreId = storeId
        };
    }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
