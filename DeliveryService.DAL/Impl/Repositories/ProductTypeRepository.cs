using DeliveryService.DAL.Impl.Repositories;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class ProductTypeRepository : Repository<ProductType, int>, IProductTypeRepository
    {
        public ProductTypeRepository() : base()
        {

        }
    }
}