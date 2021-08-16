using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.BLL.Impl.Mappers;
using DeliveryService.DAL.Abstr.UOW;
using DeliveryService.BLL.Abstr;
using DeliveryService.Model;

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
