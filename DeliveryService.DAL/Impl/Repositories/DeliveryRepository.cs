using DeliveryService.Entity;
using System.Collections.Generic;
using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.DAL.Impl.EF;

namespace DeliveryService.DAL.Impl.Repositories
{
    public class DeliveryRepository : Repository<Delivery, int>, IDeliveryRepository
    {
        public DeliveryRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}
