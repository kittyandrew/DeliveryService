using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class PlaceRepository : Repository<Place, int>, IPlaceRepository
    {
        public PlaceRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}
