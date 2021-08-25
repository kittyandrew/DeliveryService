using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.DAL.Abstr.UOW;
using System.Collections.Generic;
using DeliveryService.Entity;
using System;

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

        public void InitializeData()
        {
            // TransportTypes

            TransportType transportType1 = new TransportType("SUV", 25, 50, 100);
            TransportType transportType2 = new TransportType("Van", 50, 200, 80);
            TransportType transportType3 = new TransportType("Truck", 200, 750, 45);

            TransportTypes.Create(transportType1);
            TransportTypes.Create(transportType2);
            TransportTypes.Create(transportType3);

            // Transports

            Transports.Create(new Transport(DateTime.Now, transportType1));
            Transports.Create(new Transport(DateTime.Now, transportType1));
            Transports.Create(new Transport(DateTime.Now, transportType1));
            Transports.Create(new Transport(DateTime.Now, transportType2));
            Transports.Create(new Transport(DateTime.Now, transportType2));
            Transports.Create(new Transport(DateTime.Now, transportType3));
            Transports.Create(new Transport(DateTime.Now, transportType3));

            // ProductTypes

            ProductType productType1 = new ProductType("Computers");
            productType1.TransportTypes.Add(transportType1);
            productType1.TransportTypes.Add(transportType2);
            productType1.TransportTypes.Add(transportType3);
            ProductTypes.Create(productType1);

            ProductType productType2 = new ProductType("Television");
            productType2.TransportTypes.Add(transportType2);
            productType2.TransportTypes.Add(transportType3);
            ProductTypes.Create(productType2);
            
            ProductType productType3 = new ProductType("Soft Items");
            productType3.TransportTypes.Add(transportType1);
            productType3.TransportTypes.Add(transportType2);
            ProductTypes.Create(productType3);

            ProductType productType4 = new ProductType("Furniture");
            productType4.TransportTypes.Add(transportType2);
            productType4.TransportTypes.Add(transportType3);
            ProductTypes.Create(productType4);

            ProductType productType5 = new ProductType("Couches");
            productType5.TransportTypes.Add(transportType3);
            ProductTypes.Create(productType5);

            // Products

            Products.Create(new Product("IPhone", 1, 0.1, productType1));
            Products.Create(new Product("45' Samsung", 25, 40, productType2));
            Products.Create(new Product("65' Samsung", 35, 75, productType2));
            Products.Create(new Product("80' Samsung", 45, 100, productType2));
            Products.Create(new Product("Small Pillow", 10, 3, productType3));
            Products.Create(new Product("Big Pillow", 30, 10, productType3));
            Products.Create(new Product("Chair", 85, 350, productType4));
            Products.Create(new Product("Sofa", 180, 720, productType5));

            // Places

            Places.Create(new Place("Kyiv", 20, 0.1));
            Places.Create(new Place("Lviv", 400, 0.2));
            Places.Create(new Place("Odessa", 860, 0.3));
            Places.Create(new Place("Bila Tserkva", 65, 0.95));
            Places.Create(new Place("Vishneve", 10, 0.3));
        }
    }
}
