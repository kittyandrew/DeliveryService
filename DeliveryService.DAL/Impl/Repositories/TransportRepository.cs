using System.Collections.Generic;
using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.Entity;
using System.Linq;
using DeliveryService.DAL.Impl.EF;
using System;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class TransportRepository : Repository<Transport, int>, ITransportRepository
    {
        public TransportRepository(DeliveryServiceContext context) : base(context)
        {

        }

        public Transport GetFirstFreeAndSuitable(Product product)
        {
            IList<int> Ids = product.ProductType.TransportForProducts.Select(tt => tt.TransportTypeId).ToList();
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
