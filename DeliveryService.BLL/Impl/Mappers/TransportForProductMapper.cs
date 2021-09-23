using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Impl.Mappers
{
    public static class TransportForProductMapper
    {
        public static TransportForProduct ModelToEntity(this TransportForProductModel transportForProductModel)
        {
            return new TransportForProduct
            {
                Id = transportForProductModel.Id,
                TransportTypeId = transportForProductModel.TransportTypeModel.Id,
                ProductTypeId = transportForProductModel.ProductTypeModel.Id
            };
        }

        public static TransportForProductModel EntityToModel(this TransportForProduct transportForProduct)
        {
            return new TransportForProductModel
            {
                Id = transportForProduct.Id,
                TransportTypeModel = transportForProduct.TransportType.EntityToModel(),
                ProductTypeModel = transportForProduct.ProductType.EntityToModel(),
            };
        }
    }
}
