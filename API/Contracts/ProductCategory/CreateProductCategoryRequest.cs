namespace API.Contracts.ProductCategory;

/// <summary>
/// The request to create a product category
/// </summary>
public class CreateProductCategoryRequest
{
    /// <summary>
    /// The name of the product category
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description of the product category
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The store Id
    /// </summary>
    public long StoreId { get; set; }
}
