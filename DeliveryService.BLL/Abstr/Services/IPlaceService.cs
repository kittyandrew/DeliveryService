using System;
using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Abstr.Services
{
    public interface IPlaceService
    {
        ICollection<PlaceModel> GetAllPlaces();
    }
}
