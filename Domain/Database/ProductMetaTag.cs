using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Database
{
    public class ProductMetaTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public long StoreId { get; set; }   
        public virtual Store Store { get; set; }    
        public ICollection<Product> Products { get; set; }
    }
}
