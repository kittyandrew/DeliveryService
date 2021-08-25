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
    }
}