namespace Domain.Database
{
    public class ProductMetaTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public long StoreId { get; set; }   
        public virtual Store Store { get; set; }    
        public ICollection<Product> Products { get; set; }
        
        public static ProductMetaTag CreateProductMetaTag(string tag, long storeId)
        {
            return new ProductMetaTag
            {
                Tag = tag,
                StoreId = storeId
            };
        }
        
    }
}
