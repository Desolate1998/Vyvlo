using System.Text.Json.Serialization;

namespace Domain.Database;

public class ProductMetaTag
{
    public long Id { get; set; }
    public string Tag { get; set; }
    public long ProductId { get; set; }

    [JsonIgnore]
    public virtual Product Product{ get; set; }
    
    public static ProductMetaTag CreateProductMetaTag(string tag, long productId)
    {
        return new ProductMetaTag
        {
            Tag = tag,
            ProductId = productId
        };
    }
}
