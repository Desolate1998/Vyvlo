using Domain.Database;
using Domain.Repository_Interfaces;
using Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

internal class MetaTagRepository(DataContext context) : IMetaTagRepository
{
    async Task IMetaTagRepository.AddMetaTags(ICollection<ProductMetaTag> tags)
    {
       context.ProductMetaTags.AddRange(tags);
       await context.SaveChangesAsync();
    }
}
