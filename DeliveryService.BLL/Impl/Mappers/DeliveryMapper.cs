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
                PlaceId = deliveryModel.PlaceModel.Id,
                Place = PlaceMapper.ModelToEntity(deliveryModel.PlaceModel),
                TransportId = deliveryModel.PlaceModel.Id,
                Transport = TransportMapper.ModelToEntity(deliveryModel.TransportModel),
                ProductId = deliveryModel.PlaceModel.Id,
                Product = ProductMapper.ModelToEntity(deliveryModel.ProductModel),
            };
        }

        public static DeliveryModel EntityToModel(this Delivery delivery)
        {
            return new DeliveryModel
            {
                Id = delivery.Id,
                DeliveryTime = delivery.DeliveryTime,
                PlaceModel = PlaceMapper.EntityToModel(delivery.Place),
                TransportModel = TransportMapper.EntityToModel(delivery.Transport),
                ProductModel = ProductMapper.EntityToModel(delivery.Product),
            };
        }
    }
}
