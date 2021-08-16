using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class ProductTypeRepository : Repository<ProductType, int>, IProductTypeRepository
    {
        public ProductTypeRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}