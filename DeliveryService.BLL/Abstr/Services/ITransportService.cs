using System;
using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Abstr.Services
{
    public interface ITransportService
    {
        TimeSpan GetDeliveryTime(PlaceModel placeModel, TransportModel transportModel);
    }
}
