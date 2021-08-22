using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.DAL.Abstr.UOW;
using DeliveryService.Entity;
using DeliveryService.BLL.Abstr.Services;

namespace DeliveryService.BLL.Impl.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork UnitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public ICollection<Product> GetAllProducts()
        {
            return UnitOfWork.Products.GetAll();
        }
    }
}
