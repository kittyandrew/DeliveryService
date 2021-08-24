using Microsoft.Extensions.DependencyInjection;
using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.DAL.Abstr.UOW;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.DAL.Impl.Repositories;
using DeliveryService.DAL.Impl.UOW;

namespace DeliveryService.DAL
{
    public static class DALDependencies
    {
        public static IServiceCollection RegisterDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<DeliveryServiceContext, DeliveryServiceContext>();

            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<ITransportRepository, TransportRepository>();
            services.AddScoped<ITransportTypeRepository, TransportTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
