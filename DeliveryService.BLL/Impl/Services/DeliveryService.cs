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
            Transport transport = UnitOfWork.Transports.GetFirstFreeAndSuitable(product);
            TimeSpan hours = TransportService.GetDeliveryTime(place, transport);
            DateTime deliveryTime;
            // If transport is not ready yet -> schedule according to its time.
            if (transport.FreeBy > DateTime.Now) deliveryTime = transport.FreeBy + hours;
            // Otherwise, schedule right now.
            else                                 deliveryTime = DateTime.Now + hours;

            transport.FreeBy = deliveryTime;
            UnitOfWork.Transports.Update(transport);

            Delivery delivery = new Delivery(deliveryTime, place, transport, product);
            
            UnitOfWork.Deliveries.Create(delivery);
            UnitOfWork.Save();
            return delivery;
        }

        public void CancelDelivery(Delivery delivery)
        {
            // If transport is not ready yet -> free by cancelled hours.
            if (delivery.Transport.FreeBy > DateTime.Now)
            {
                delivery.Transport.FreeBy -= TransportService.GetDeliveryTime(delivery.Place, delivery.Transport);
                UnitOfWork.Transports.Update(delivery.Transport);
            }

            UnitOfWork.Deliveries.Delete(delivery.Id);
            UnitOfWork.Save();
        }
    }
}
