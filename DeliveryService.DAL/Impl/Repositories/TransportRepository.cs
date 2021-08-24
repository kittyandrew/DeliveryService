using System.Collections.Generic;
using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.Entity;
using System.Linq;
using System;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class TransportRepository : Repository<Transport, int>, ITransportRepository
    {
        public TransportRepository(DeliveryServiceContext context) : base(context)
        {

        }

        public Transport GetFirstFree(Product product)
        {
            return DbSet.Where(
                t => t.TransportType.MaxSize >= product.Size
                  || t.TransportType.MaxWeight >= product.Weight
            ).OrderBy(t => t.FreeBy).First();
        }
    }
}
