using System;
using DeliveryService.Entity;

namespace DeliveryService.BLL.Abstr.Services
{
    public interface ITransportService
    {
        TimeSpan GetDeliveryTime(Place place, Transport transport);
    }
}
