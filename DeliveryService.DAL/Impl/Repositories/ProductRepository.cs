using DeliveryService.DAL.Impl.Repositories;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository() : base()
        {

        }

        protected override void Initialize(ICollection<Product> DbSet)
        {
            DbSet.Add(new Product("IPhone", 1, 0.1, 1));
            DbSet.Add(new Product("45' Samsung", 25, 40, 1));
            DbSet.Add(new Product("65' Samsung", 35, 75, 1));
            DbSet.Add(new Product("80' Samsung", 45, 100, 1));
            DbSet.Add(new Product("Small Pillow", 10, 3, 2));
            DbSet.Add(new Product("Big Pillow", 30, 10, 2));
            DbSet.Add(new Product("Chair", 85, 350, 3));
            DbSet.Add(new Product("Sofa", 180, 720, 4));
        }
    }
}
