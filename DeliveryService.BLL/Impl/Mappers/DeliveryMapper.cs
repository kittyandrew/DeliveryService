using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Impl.Mappers
{
    public static class DeliveryMapper
    {
        public static Delivery ModelToEntity(this DeliveryModel deliveryModel)
        {
            return new Delivery
            {
                Id = deliveryModel.Id,
                DeliveryTime = deliveryModel.DeliveryTime,
                Place = deliveryModel.PlaceModel.ModelToEntity(),
                PlaceId = deliveryModel.PlaceModel.Id,
                Transport = deliveryModel.TransportModel.ModelToEntity(),
                TransportId = deliveryModel.TransportModel.Id,
                Product = deliveryModel.ProductModel.ModelToEntity(),
                ProductId = deliveryModel.ProductModel.Id
            };
        }

        public static DeliveryModel EntityToModel(this Delivery delivery)
        {
            return new DeliveryModel
            {
                Id = delivery.Id,
                DeliveryTime = delivery.DeliveryTime,
                PlaceModel = delivery.Place.EntityToModel(),
                TransportModel = delivery.Transport.EntityToModel(),
                ProductModel = delivery.Product.EntityToModel(),
            };
        }
    }
}
