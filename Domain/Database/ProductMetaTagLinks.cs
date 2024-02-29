using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Database;

public class ProductMetaTagLinks
{
    public long ProductId { get; set; }
    public long MetaTagId { get; set; }
    public virtual Product Product{ get; set; }
    public virtual ProductMetaTag ProductMetaTag { get; set; }
}
