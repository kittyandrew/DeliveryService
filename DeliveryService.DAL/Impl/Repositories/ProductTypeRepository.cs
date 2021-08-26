using DeliveryService.DAL.Impl.Repositories;
using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.DAL.Impl.EF;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class ProductTypeRepository : Repository<ProductType, int>, IProductTypeRepository
    {
        public ProductTypeRepository(DeliveryServiceContext context) : base(context)
        {

        }
    }
}