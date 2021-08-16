using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Impl.Mappers
{
    public static class PlaceMapper
    {
        public static Place ModelToEntity(this PlaceModel placeModel)
        {
            return new Place
            {
                Id = placeModel.Id,
                Name = placeModel.Name,
                Distance = placeModel.Distance,
                Traffic = placeModel.Traffic
            };
        }

        public static PlaceModel EntityToModel(this Place place)
        {
            return new PlaceModel
            {
                Id = place.Id,
                Name = place.Name,
                Distance = place.Distance,
                Traffic = place.Traffic
            };
        }
    }
}
