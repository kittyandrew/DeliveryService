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
using DeliveryService.DAL.Impl.EF;

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
            DeliveryServiceContext context = new DeliveryServiceContext();

            IDeliveryRepository deliveryRepository = new DeliveryRepository(context);
            IPlaceRepository placeRepository = new PlaceRepository(context);
            IProductRepository productRepository = new ProductRepository(context);
            IProductTypeRepository productTypeRepository = new ProductTypeRepository(context);
            ITransportRepository transportRepository = new TransportRepository(context);
            ITransportTypeRepository transportTypeRepository = new TransportTypeRepository(context);
            ITransportForProductRepository transportForProductRepository = new TransportForProductRepository(context);

            IUnitOfWork unitOfWork = new UnitOfWork(
                context,
                placeRepository, transportRepository,
                productRepository, transportTypeRepository,
                productTypeRepository, deliveryRepository,
                transportForProductRepository
            );

            transportService = new TransportService(unitOfWork);
            placeService = new PlaceService(unitOfWork);
            productService = new ProductService(unitOfWork);
            deliveryService = new MainDeliveryService(unitOfWork, transportService);
        }
    }
}
