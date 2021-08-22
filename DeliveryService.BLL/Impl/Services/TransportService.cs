using System;
using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.BLL.Abstr.Services;
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

        public Transport GetSuitableTransport(Product product)
        {
            ProductType productType = UnitOfWork.ProductTypes.Get(product.ProductTypeId);
            return UnitOfWork.Transports.GetFirstFree(productType.TransportTypeId);
        }

        public TimeSpan GetDeliveryTime(Place place, Transport transport)
        {
            TransportType transportType = UnitOfWork.TransportTypes.Get(transport.TransportTypeId);
            // Here we calculate time (in hours) using vehicle speed, delivery place distance and its traffic coeff:
            return new TimeSpan((int)Math.Ceiling(place.Distance / (transportType.Speed * Math.Pow(place.Traffic, place.Traffic))), 0, 0);
            
        }

    }
}
