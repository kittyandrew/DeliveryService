using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliveryService.Entity;
using System.Threading.Tasks;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public interface ITransportForProductRepository : IRepository<TransportForProduct, int>
    {
        ICollection<TransportForProduct> GetAllForProductType(ProductType productType);
    }
}
