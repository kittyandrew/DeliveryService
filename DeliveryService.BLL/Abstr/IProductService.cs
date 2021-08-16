using System;
using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.BLL.Abstr
{
    public interface IProductService
    {
        ICollection<ProductModel> GetAllProducts();
    }
}
