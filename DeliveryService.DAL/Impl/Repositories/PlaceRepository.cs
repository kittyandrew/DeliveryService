using DeliveryService.DAL.Impl.Repositories;
using System.Collections.Generic;
using DeliveryService.Entity;
using System.Linq;
using System;
using DeliveryService.DAL.Impl.EF;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class PlaceRepository : Repository<Place, int>, IPlaceRepository
    {
        public PlaceRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}
