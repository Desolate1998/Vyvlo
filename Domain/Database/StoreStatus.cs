using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Database;

public class StoreStatus
{
    public string StoreStatusCode { get; private set; }
    public string Description { get; private set; }
    public virtual ICollection<Store> Stores { get; private set; }    
}
