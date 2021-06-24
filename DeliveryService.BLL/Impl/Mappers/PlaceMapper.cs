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
                Distance = placeModel.Distance,
                Traffic = placeModel.Traffic
            };
        }

        public static PlaceModel EntityToModel(this Place place)
        {
            return new PlaceModel
            {
                Distance = place.Distance,
                Traffic = place.Traffic
            };
        }
    }
}
