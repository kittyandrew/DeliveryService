using System;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public interface IDeliveryRepository : IRepository<Delivery, int>
    {
    }
}