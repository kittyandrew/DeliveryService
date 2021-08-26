using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.DAL.Abstr.Repositories;

namespace DeliveryService.DAL.Impl.Repositories
{
    public class TransportForProductRepository : Repository<TransportForProduct, int>, ITransportForProductRepository
    {
        public TransportForProductRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}
