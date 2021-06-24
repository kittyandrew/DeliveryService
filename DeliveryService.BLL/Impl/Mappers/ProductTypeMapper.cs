using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Impl.Mappers
{
    public static class ProductTypeMapper
    {
        public static ProductType ModelToEntity(this ProductTypeModel productTypeModel)
        {
            return new ProductType
            {
                Id = productTypeModel.Id,
                Name = productTypeModel.Name,
                TransportTypeId = productTypeModel.TransportTypeModel.Id,
                TransportType = TransportTypeMapper.ModelToEntity(productTypeModel.TransportTypeModel),
            };
        }

        public static ProductTypeModel EntityToModel(this ProductType productType)
        {
            return new ProductTypeModel
            {
                Id = productType.Id,
                Name = productType.Name,
                TransportTypeModel = TransportTypeMapper.EntityToModel(productType.TransportType)
            };
        }
    }
}