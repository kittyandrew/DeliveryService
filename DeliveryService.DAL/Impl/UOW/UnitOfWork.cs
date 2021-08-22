using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.DAL.Abstr.UOW;

namespace DeliveryService.DAL.Impl.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDeliveryRepository Deliveries { get; }
        public IPlaceRepository Places { get; }
        public ITransportRepository Transports { get; }
        public ITransportTypeRepository TransportTypes { get; }
        public IProductRepository Products { get; }
        public IProductTypeRepository ProductTypes { get; }

        public UnitOfWork(
            IPlaceRepository places, ITransportRepository transports,
            IProductRepository products, ITransportTypeRepository transportTypes,
            IProductTypeRepository productTypes, IDeliveryRepository deliveries
        )
        {
            Deliveries = deliveries;
            Places = places;
            Transports = transports;
            TransportTypes = transportTypes;
            Products = products;
            ProductTypes = productTypes;
        }

        public void Save()
        {
            
        }
    }
}
