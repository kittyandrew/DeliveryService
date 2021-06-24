using System;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}
