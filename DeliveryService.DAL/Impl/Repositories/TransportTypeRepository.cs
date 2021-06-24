using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class TransportTypeRepository : Repository<TransportType, int>, ITransportTypeRepository
    {
        public TransportTypeRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}