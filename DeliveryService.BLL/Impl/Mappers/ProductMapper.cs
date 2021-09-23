using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Impl.Mappers
{
    public static class ProductMapper
    {
        public static Product ModelToEntity(this ProductModel productModel)
        {
            return new Product
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Size = productModel.Size,
                Weight = productModel.Weight,
                ProductType = productModel.ProductTypeModel.ModelToEntity(),
                ProductTypeId = productModel.ProductTypeModel.Id
            };
        }

        public static ProductModel EntityToModel(this Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Size = product.Size,
                Weight = product.Weight,
                ProductTypeModel = product.ProductType.EntityToModel(),
            };
        }
    }
}
