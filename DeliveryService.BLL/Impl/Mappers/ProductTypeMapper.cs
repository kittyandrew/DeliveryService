using DeliveryService.Entity;
using DeliveryService.Model;
using System.Linq;

namespace DeliveryService.BLL.Impl.Mappers
{
    public static class ProductTypeMapper
    {
        public static ProductType ModelToEntity(this ProductTypeModel productTypeModel)
        {
            return new ProductType
            {
                Id = productTypeModel.Id,
                Name = productTypeModel.Name
            };
        }
        public static ProductTypeModel EntityToModel(this ProductType productType)
        {
            return new ProductTypeModel
            {
                Id = productType.Id,
                Name = productType.Name
            };
        }
    }
}
