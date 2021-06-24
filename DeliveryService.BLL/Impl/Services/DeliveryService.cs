using System;
using DeliveryService.Model;
using DeliveryService.Entity;
using DeliveryService.BLL.Abstr;
using DeliveryService.DAL.Abstr.UOW;
using DeliveryService.BLL.Impl.Mappers;


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

        public DeliveryModel MakeDelivery(ProductModel product, PlaceModel place)
        {
            Transport transport = TransportService.GetSuitableTransport(product.ProductTypeModel.ModelToEntity());
            TimeSpan deliveryTime = TransportService.GetDeliveryTimeMinutes(place.ModelToEntity(), transport);

            DateTime newDeliveryTime = transport.FreeBy + deliveryTime;
            transport.FreeBy = newDeliveryTime;
            UnitOfWork.Transports.Update(transport);

            Delivery delivery = new Delivery
            {
                DeliveryTime = newDeliveryTime,
                Transport = transport,
                Place = place.ModelToEntity(),
                Product = product.ModelToEntity(),
            };
            UnitOfWork.Deliveries.Create(delivery);
            UnitOfWork.Save();
            return delivery.EntityToModel();
        }
    }
}
