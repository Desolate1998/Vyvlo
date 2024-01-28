using System.Collections;

namespace API.Contracts.Product;

public class CreateNewProductRequest
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public ICollection<long> Categories { get; set; }
    public ICollection<string> MetaTags { get; set; }
    public decimal Price { get; set; }
    public bool EnableStockTracking { get; set; }
    public int Stock { get; set; }
    public ICollection<IFormFile> Images { get; set; }
    public long StoreId { get; set; }
}
