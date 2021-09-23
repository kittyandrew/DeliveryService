using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.DAL.Abstr.UOW;
using DeliveryService.Entity;
using DeliveryService.Model;
using DeliveryService.BLL.Abstr.Services;
using DeliveryService.BLL.Impl.Mappers;

namespace DeliveryService.BLL.Impl.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork UnitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public ICollection<ProductModel> GetAllProducts()
        {
            return UnitOfWork.Products.GetAll().Select(p => p.EntityToModel()).ToList();
        }
    }
}
