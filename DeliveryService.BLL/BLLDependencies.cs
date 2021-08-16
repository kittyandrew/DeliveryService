using Microsoft.Extensions.DependencyInjection;
using DeliveryService.BLL.Impl.Services;
using DeliveryService.BLL.Abstr;

namespace DeliveryService.BLL
{
    public static class BLLDependencies
    {
        public static IServiceCollection RegisterBLLDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IPlaceService, PlaceService>();
            services.AddSingleton<IDeliveryService, MainDeliveryService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ITransportService, TransportService>();
            return services;
        }
    }
}