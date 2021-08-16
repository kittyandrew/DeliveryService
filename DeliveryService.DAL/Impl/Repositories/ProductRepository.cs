using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}
