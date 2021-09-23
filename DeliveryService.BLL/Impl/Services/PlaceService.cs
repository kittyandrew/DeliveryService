using System;
using DeliveryService.Entity;
using DeliveryService.BLL.Abstr.Services;
using DeliveryService.BLL.Impl.Mappers;
using DeliveryService.DAL.Abstr.UOW;
using System.Collections.Generic;
using DeliveryService.Model;
using System.Linq;

namespace DeliveryService.BLL.Impl.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork UnitOfWork;

        public PlaceService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public ICollection<PlaceModel> GetAllPlaces()
        {
            return UnitOfWork.Places.GetAll().Select(p => p.EntityToModel()).ToList() ;
        }
    }
}
