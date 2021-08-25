using System.Collections.Generic;
using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.Entity;
using System.Linq;
using System;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class TransportRepository : Repository<Transport, int>, ITransportRepository
    {
        public TransportRepository() : base()
        {

        }

        public Transport GetFirstFreeAndSuitable(Product product)
        {
            IList<int> Ids = product.ProductType.TransportTypes.Select(tt => tt.Id).ToList();
            return DbSet.Where(
                t => Ids.Contains(t.TransportType.Id)
                  && t.TransportType.MaxSize >= product.Size
                  && t.TransportType.MaxWeight >= product.Weight
            )
                .OrderBy(t => t.FreeBy)
                .ThenBy(t => t.TransportType.MaxSize)
                .ThenBy(t => t.TransportType.MaxWeight)
                .First();
        }
    }
}
