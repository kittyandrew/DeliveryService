using System;
using DeliveryService.Entity;
using DeliveryService.Model;
using DeliveryService.BLL.Abstr.Services;
using DeliveryService.DAL.Abstr.UOW;
using System.Collections.Generic;
using DeliveryService.BLL.Impl.Mappers;
using System.Linq;

namespace DeliveryService.BLL.Impl.Services
{
    public class MainDeliveryService : IDeliveryService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly ITransportService TransportService;

        public MainDeliveryService(IUnitOfWork unitOfWork, ITransportService transportService)
        {
            UnitOfWork = unitOfWork;
            TransportService = transportService;
        }

        public ICollection<DeliveryModel> GetAllDeliveries()
        {
            return UnitOfWork.Deliveries.GetAll().Select(d => d.EntityToModel()).ToList();
        }

        public DeliveryModel MakeDelivery(ProductModel productModel, PlaceModel placeModel)
        {
            // Loading all transport for products from database to check for transport type.
            Product product = productModel.ModelToEntity();
            product.ProductType.TransportForProducts = UnitOfWork.TransportForProducts.GetAllForProductType(product.ProductType);
            // Getting the most suitable vehicle from the database.
            Transport transport = UnitOfWork.Transports.GetFirstFreeAndSuitable(product);
            // Evaluating time it will take for the vehicle to get to the target place.
            TimeSpan hours = TransportService.GetDeliveryTime(placeModel, transport.EntityToModel());

            DateTime deliveryTime;
            // If transport is not available at the moment, schedule for later according to its time.
            if (transport.FreeBy > DateTime.Now) deliveryTime = transport.FreeBy + hours;
            // Otherwise, schedule right now.
            else                                 deliveryTime = DateTime.Now + hours;

            transport.FreeBy = deliveryTime;
            UnitOfWork.Transports.Update(transport);

            Delivery delivery = new Delivery()
            {
                DeliveryTime = deliveryTime,
                Place = placeModel.ModelToEntity(),
                PlaceId = placeModel.Id,
                Transport = transport,
                TransportId = transport.Id,
                Product = productModel.ModelToEntity(),
                ProductId = productModel.Id,
            };

            UnitOfWork.Deliveries.Create(delivery);
            UnitOfWork.Save();
            return delivery.EntityToModel();
        }

        public void CancelDelivery(DeliveryModel deliveryModel)
        {
            Delivery delivery = UnitOfWork.Deliveries.Get(deliveryModel.Id);

            // If transport is not available yet -> free by cancelled hours.
            if (deliveryModel.TransportModel.FreeBy > DateTime.Now)
            {
                delivery.Transport.FreeBy -= TransportService.GetDeliveryTime(deliveryModel.PlaceModel, deliveryModel.TransportModel);
                UnitOfWork.Transports.Update(delivery.Transport);
            }

            UnitOfWork.Deliveries.Delete(delivery);
            UnitOfWork.Save();
        }
    }
}
