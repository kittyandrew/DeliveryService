using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.DAL.Abstr.UOW;
using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.DAL.Impl.UOW;
using DeliveryService.BLL.Abstr.Services;
using DeliveryService.BLL.Impl.Services;

namespace DeliveryService.BLL.Impl
{
    public class ServiceCollection
    {
        public IDeliveryService deliveryService;
        public IPlaceService placeService;
        public IProductService productService;
        public ITransportService transportService;

        public ServiceCollection()
        {
            IDeliveryRepository deliveryRepository = new DeliveryRepository();
            IPlaceRepository placeRepository = new PlaceRepository();
            IProductRepository productRepository = new ProductRepository();
            IProductTypeRepository productTypeRepository = new ProductTypeRepository();
            ITransportRepository transportRepository = new TransportRepository();
            ITransportTypeRepository transportTypeRepository = new TransportTypeRepository();

            IUnitOfWork unitOfWork = new UnitOfWork(
                placeRepository, transportRepository,
                productRepository, transportTypeRepository,
                productTypeRepository, deliveryRepository
            );

            // Initializing test data.
            unitOfWork.InitializeData();

            transportService = new TransportService(unitOfWork);
            placeService = new PlaceService(unitOfWork);
            productService = new ProductService(unitOfWork);
            deliveryService = new MainDeliveryService(unitOfWork, transportService);
        }
    }
}
