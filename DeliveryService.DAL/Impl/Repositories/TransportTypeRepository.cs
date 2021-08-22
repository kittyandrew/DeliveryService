using DeliveryService.DAL.Impl.Repositories;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class TransportTypeRepository : Repository<TransportType, int>, ITransportTypeRepository
    {
        public TransportTypeRepository() : base()
        {

        }

        protected override void Initialize(ICollection<TransportType> DbSet)
        {
            DbSet.Add(new TransportType("SUV", 25, 50, 100));
            DbSet.Add(new TransportType("Van", 50, 200, 80));
            DbSet.Add(new TransportType("Truck", 200, 750, 45));
        }
    }
}