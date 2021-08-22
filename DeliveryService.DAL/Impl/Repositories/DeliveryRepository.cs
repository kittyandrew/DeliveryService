using DeliveryService.Entity;
using System.Collections.Generic;
using DeliveryService.DAL.Abstr.Repositories;

namespace DeliveryService.DAL.Impl.Repositories
{
    public class DeliveryRepository : Repository<Delivery, int>, IDeliveryRepository
    {
        public DeliveryRepository() : base()
        {

        }

        protected override void Initialize(ICollection<Delivery> DbSet)
        {
            
        }
    }
}
