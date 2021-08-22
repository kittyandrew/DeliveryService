using System;
using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.BLL.Abstr.Services
{
    public interface IProductService
    {
        ICollection<Product> GetAllProducts();
    }
}
