using DeliveryService.DAL.Impl.EF;
using DeliveryService.Entity;
using DeliveryService.DAL.Abstr.Repositories;

namespace DeliveryService.DAL.Impl.Repositories
{
    public class DeliveryRepository : Repository<Delivery, int>, IDeliveryRepository
    {
        public DeliveryRepository(DeliveryServiceContext context) : base(context)
        {

        }
}
}
