using System;
using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.BLL.Abstr;
using DeliveryService.DAL.Abstr.UOW;

namespace DeliveryService.BLL.Impl.Services
{
    public class TransportService : ITransportService
    {
        private readonly IUnitOfWork UnitOfWork;

        public TransportService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Transport GetSuitableTransport(ProductType productType)
        {
            return UnitOfWork.Transports.GetFirstFree(productType.TransportType);
        }

        public TimeSpan GetDeliveryTimeMinutes(Place place, Transport transport)
        {
            // Here we calculate time (in minutes) using vehicle speed, delivery place distance and its traffic coeff:
            return new TimeSpan(0, (int)Math.Ceiling(place.Distance / (transport.TransportType.Speed * Math.Pow(place.Traffic, place.Traffic))), 0);
        }

    }
}
