using System;
using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.DAL.Abstr.UOW;
using DeliveryService.DAL.Impl.EF;

namespace DeliveryService.DAL.Impl.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryServiceContext Context;

        public IDeliveryRepository      Deliveries { get; }
        public IPlaceRepository         Places { get; }
        public ITransportRepository     Transports { get; }
        public ITransportTypeRepository TransportTypes { get; }
        public IProductRepository       Products { get; }
        public IProductTypeRepository   ProductTypes { get; }

        public UnitOfWork(
            DeliveryServiceContext context, IPlaceRepository places,
            ITransportRepository transports, IProductRepository products,
            ITransportTypeRepository transportTypes, IProductTypeRepository productTypes,
            IDeliveryRepository deliveries
        )
        {
            Deliveries = deliveries;
            Context = context;
            Places = places;
            Transports = transports;
            TransportTypes = transportTypes;
            Products = products;
            ProductTypes = productTypes;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
