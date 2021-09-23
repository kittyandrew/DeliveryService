using System;
using System.Collections.Generic;
using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Abstr.Services
{
    public interface IProductService
    {
        ICollection<ProductModel> GetAllProducts();
    }
}
