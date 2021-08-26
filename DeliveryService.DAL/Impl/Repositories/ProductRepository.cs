using DeliveryService.DAL.Impl.Repositories;
using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.DAL.Impl.EF;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}
