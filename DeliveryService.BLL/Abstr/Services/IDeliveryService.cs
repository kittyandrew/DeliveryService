using System;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.BLL.Abstr.Services
{
    public interface IDeliveryService
    {
        ICollection<Delivery> GetAllDeliveries();
        void CancelDelivery(Delivery deliveryModel);
        Delivery MakeDelivery(Product product, Place place);
    }
}
