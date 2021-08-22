using System.Collections.Generic;
using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.Entity;
using System.Linq;
using System;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class TransportRepository : Repository<Transport, int>, ITransportRepository
    {
        public TransportRepository() : base()
        {

        }

        protected override void Initialize(ICollection<Transport> DbSet)
        {
            DbSet.Add(new Transport(DateTime.Now, 1));
            DbSet.Add(new Transport(DateTime.Now, 1));
            DbSet.Add(new Transport(DateTime.Now, 1));
            DbSet.Add(new Transport(DateTime.Now, 2));
            DbSet.Add(new Transport(DateTime.Now, 2));
            DbSet.Add(new Transport(DateTime.Now, 3));
            DbSet.Add(new Transport(DateTime.Now, 3));
        }

        public Transport GetFirstFree(int transportTypeId)
        {
            return DbSet.Where(t => t.TransportTypeId == transportTypeId).OrderBy(t => t.FreeBy).First();
        }
    }
}
