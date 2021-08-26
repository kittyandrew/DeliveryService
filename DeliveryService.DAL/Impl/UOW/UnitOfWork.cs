using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.DAL.Abstr.UOW;
using System.Collections.Generic;
using DeliveryService.Entity;
using System;
using DeliveryService.DAL.Impl.EF;

namespace DeliveryService.DAL.Impl.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryServiceContext context;
        public IDeliveryRepository Deliveries { get; }
        public IPlaceRepository Places { get; }
        public ITransportRepository Transports { get; }
        public ITransportTypeRepository TransportTypes { get; }
        public IProductRepository Products { get; }
        public IProductTypeRepository ProductTypes { get; }
        public ITransportForProductRepository TransportForProducts { get; }

        public UnitOfWork(
            DeliveryServiceContext Context,
            IPlaceRepository places, ITransportRepository transports,
            IProductRepository products, ITransportTypeRepository transportTypes,
            IProductTypeRepository productTypes, IDeliveryRepository deliveries,
            ITransportForProductRepository transportForProducts
        )
        {
            context = Context;
            Deliveries = deliveries;
            Places = places;
            Transports = transports;
            TransportTypes = transportTypes;
            Products = products;
            ProductTypes = productTypes;
            TransportForProducts = transportForProducts;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
