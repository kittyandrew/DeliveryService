using System;
using DeliveryService.Entity;
using DeliveryService.BLL.Abstr.Services;
using DeliveryService.DAL.Abstr.UOW;
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

        public ICollection<Delivery> GetAllDeliveries()
        {
            return UnitOfWork.Deliveries.GetAll();
        }

        public Delivery MakeDelivery(Product product, Place place)
        {
            // Getting the most suitable vehicle from the database.
            Transport transport = UnitOfWork.Transports.GetFirstFreeAndSuitable(product);
            // Evaluating time it will take for the vehicle to get to the target place.
            TimeSpan hours = TransportService.GetDeliveryTime(place, transport);

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
                Place = place,
                PlaceId = place.Id,
                Transport = transport,
                TransportId = transport.Id,
                Product = product,
                ProductId = product.Id,
            };

            UnitOfWork.Deliveries.Create(delivery);
            UnitOfWork.Save();
            return delivery;
        }

        public void CancelDelivery(Delivery delivery)
        {
            // If transport is not available yet -> free by cancelled hours.
            if (delivery.Transport.FreeBy > DateTime.Now)
            {
                delivery.Transport.FreeBy -= TransportService.GetDeliveryTime(delivery.Place, delivery.Transport);
                UnitOfWork.Transports.Update(delivery.Transport);
            }

            UnitOfWork.Deliveries.Delete(delivery);
            UnitOfWork.Save();
        }
    }
}
