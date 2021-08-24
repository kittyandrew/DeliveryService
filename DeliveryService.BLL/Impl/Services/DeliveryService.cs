using System;
using DeliveryService.Model;
using DeliveryService.Entity;
using DeliveryService.BLL.Abstr;
using DeliveryService.DAL.Abstr.UOW;
using DeliveryService.BLL.Impl.Mappers;
using System.Collections.Generic;
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

        public DeliveryModel MakeDelivery(ProductModel product, PlaceModel place)
        {
            Transport transport = TransportService.GetSuitableTransport(product.ModelToEntity());
            TimeSpan hours = TransportService.GetDeliveryTime(place.ModelToEntity(), transport);
            DateTime deliveryTime;
            // If transport is not ready yet -> schedule according to its time.
            if (transport.FreeBy > DateTime.Now) deliveryTime = transport.FreeBy + hours;
            // Otherwise, schedule right now.
            else                                 deliveryTime = DateTime.Now + hours;

            transport.FreeBy = deliveryTime;
            UnitOfWork.Transports.Update(transport);

            Delivery delivery = new Delivery
            {
                DeliveryTime = deliveryTime,
                Transport = transport,
                TransportId = transport.Id,
                Place = place.ModelToEntity(),
                PlaceId = place.Id,
                Product = product.ModelToEntity(),
                ProductId = product.Id,
            };
            UnitOfWork.Deliveries.Create(delivery);
            UnitOfWork.Save();
            return delivery.EntityToModel();
        }

        public void CancelDelivery(DeliveryModel deliveryModel)
        {
            Transport transport = deliveryModel.TransportModel.ModelToEntity();
            // If transport is not ready yet -> free by cancelled hours.
            if (transport.FreeBy > DateTime.Now)
            {
                transport.FreeBy -= TransportService.GetDeliveryTime(
                    deliveryModel.PlaceModel.ModelToEntity(), transport
                );
                UnitOfWork.Transports.Update(transport);
            }

            UnitOfWork.Deliveries.Delete(deliveryModel.ModelToEntity());
            UnitOfWork.Save();
        }
    }
}
