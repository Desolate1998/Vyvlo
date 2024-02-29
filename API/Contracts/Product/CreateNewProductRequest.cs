using System.Collections;

namespace API.Contracts.Product;

public class CreateNewProductRequest
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string MetaTags { get; set; }
    public string Price { get; set; }
    public bool EnableStockTracking { get; set; }
    public int Stock { get; set; }
    public long StoreId { get; set; }
    public string Categories { get; set; }

    public ICollection<long> GetCategories()=> Categories.Split("&A/").Select(x => long.Parse(x)).ToList();
    public ICollection<string> GetMetaTags()=> MetaTags.Split("&A/").ToList();
    
}
