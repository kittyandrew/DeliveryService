using System;
using DeliveryService.Entity;

namespace DeliveryService.BLL.Abstr
{
    public interface ITransportService
    {
        Transport GetSuitableTransport(ProductType productType);
        TimeSpan GetDeliveryTimeMinutes(Place place, Transport transport);
    }
}
