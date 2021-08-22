using System;
using System.Collections.Generic;
using DeliveryService.DAL.Abstr.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DAL.Abstr.UOW
{
    public interface IUnitOfWork
    {
        IPlaceRepository Places { get; }
        IDeliveryRepository Deliveries { get; }
        ITransportRepository Transports { get; }
        ITransportTypeRepository TransportTypes { get; }
        IProductRepository Products { get; }
        IProductTypeRepository ProductTypes { get; }

        void Save();
    }
}
