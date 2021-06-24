using System;
using DeliveryService.Model;

namespace DeliveryService.BLL.Abstr
{
    public interface IDeliveryService
    {
        DeliveryModel MakeDelivery(ProductModel product, PlaceModel place);
    }
}
