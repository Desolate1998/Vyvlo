using System.Text.Json.Serialization;

namespace Domain.Database;

public class Product
{
    public Product()
    {
    }

    private Product(string name,
        long storeId,
        string description,
        int stock,
        decimal price)

    {
        Name = name;
        StoreId = storeId;
        Description = description;
        Stock = stock;
        Price = price;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public long StoreId { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }


    [JsonIgnore]
    public virtual ICollection<ProductCategoryLink> ProductCategoryLinks { get; set; }

    [JsonIgnore]
    public virtual Store Store { get; set; }

    [JsonIgnore]
    public virtual ICollection<ProductMetaTag> ProductMetaTags { get; set; }

    public static Product CreateProduct(
        string name,
        long storeId,
        string description,
        int stock,
        decimal price)
    {

        return new Product(
            name,
            storeId,
            description,
            stock,
            price);
    }
}