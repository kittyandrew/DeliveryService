using System;
using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.BLL.Abstr
{
    public interface IDeliveryService
    {
        ICollection<DeliveryModel> GetAllDeliveries();
        void CancelDelivery(DeliveryModel deliveryModel);
        DeliveryModel MakeDelivery(ProductModel product, PlaceModel place);
    }
}
