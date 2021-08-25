using DeliveryService.DAL.Impl.Repositories;
using System.Collections.Generic;
using DeliveryService.Entity;
using System.Linq;
using System;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class PlaceRepository : Repository<Place, int>, IPlaceRepository
    {
        public PlaceRepository() : base()
        {

        }
    }
}
