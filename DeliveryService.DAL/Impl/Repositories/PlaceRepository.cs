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

        protected override void Initialize(ICollection<Place> DbSet)
        {
            DbSet.Add(new Place("Kyiv", 20, 0.1));
            DbSet.Add(new Place("Lviv", 400, 0.2));
            DbSet.Add(new Place("Odessa", 860, 0.3));
            DbSet.Add(new Place("Bila Tserkva", 65, 0.95));
            DbSet.Add(new Place("Vishneve", 10, 0.3));
        }
    }
}
