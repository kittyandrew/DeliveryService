using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.DAL.Abstr.Repositories;
using System.Linq;
using System.Data.Entity;

namespace DeliveryService.DAL.Impl.Repositories
{
    public class TransportForProductRepository : Repository<TransportForProduct, int>, ITransportForProductRepository
    {
        public TransportForProductRepository(DeliveryServiceContext context) : base(context)
        {

        }

        public ICollection<TransportForProduct> GetAllForProductType(ProductType productType)
        {
            return DbSet.Where(tfp => tfp.ProductTypeId == productType.Id).ToList();
        }
    }
}
