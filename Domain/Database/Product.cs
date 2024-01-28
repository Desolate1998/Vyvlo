using System.Collections.Generic;

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
        decimal price,
        ICollection<ProductMetaTag> productMetaTags,
        ICollection<ProductCategoryLink> productCategoryLink)
        : this()
    {
        Name = name;
        StoreId = storeId;
        Description = description;
        Stock = stock;
        Price = price;
        ProductMetaTags = productMetaTags;
        ProductCategoryLinks = productCategoryLink;
        ProductImages = [];
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public long StoreId { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public virtual ICollection<ProductMetaTag> ProductMetaTags { get; set; }
    public virtual ICollection<ProductCategoryLink> ProductCategoryLinks { get; set; }
    public virtual Store Store { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; }

    public static Product CreateProduct(
        string name,
        long storeId,
        string description,
        int stock,
        decimal price,
        ICollection<string> metaTags,
        ICollection<long> categories)
    {
        ICollection<ProductMetaTag> tags = metaTags.Select(x => ProductMetaTag.CreateProductMetaTag(x, storeId)).ToList();
        ICollection<ProductCategoryLink> categoryLinks = categories.Select(x => ProductCategoryLink.CreateProductCategoryLink(x, storeId)).ToList();

        return new Product(
            name,
            storeId,
            description,
            stock,
            price,
            tags,
            categoryLinks);
    }
}