using System;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.BLL.Abstr.Services
{
    public interface IPlaceService
    {
        ICollection<Place> GetAllPlaces();

    }
}
