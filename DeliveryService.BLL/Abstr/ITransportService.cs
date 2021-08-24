using System;
using DeliveryService.Entity;

namespace DeliveryService.BLL.Abstr
{
    public interface ITransportService
    {
        Transport GetSuitableTransport(Product product);
        TimeSpan GetDeliveryTime(Place place, Transport transport);
    }
}
