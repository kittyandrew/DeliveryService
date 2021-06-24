using System;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public interface ITransportRepository : IRepository<Transport, int>
    {
        Transport GetFirstFree(TransportType transportType);
    }
}
