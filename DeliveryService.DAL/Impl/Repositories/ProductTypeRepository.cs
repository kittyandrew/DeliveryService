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

        protected override void Initialize(ICollection<ProductType> DbSet)
        {
            DbSet.Add(new ProductType("Computers", 1));
            DbSet.Add(new ProductType("Television", 2));
            DbSet.Add(new ProductType("Soft Items", 2));
            DbSet.Add(new ProductType("Furniture", 3));
            DbSet.Add(new ProductType("Couches", 3));
        }
    }
}