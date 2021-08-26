using DeliveryService.DAL.Impl.Repositories;
using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.DAL.Impl.EF;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class TransportTypeRepository : Repository<TransportType, int>, ITransportTypeRepository
    {
        public TransportTypeRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}