using System;
using DeliveryService.BLL.Abstr;
using DeliveryService.DAL.Abstr.UOW;

namespace DeliveryService.BLL.Impl.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork UnitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
