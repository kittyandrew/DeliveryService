using DeliveryService.DAL.Abstr.Repositories;

namespace DeliveryService.DAL.Abstr.UOW
{
    public interface IUnitOfWork
    {
        IPlaceRepository         Places     { get; }
        IDeliveryRepository      Deliveries { get; }
        ITransportRepository     Transports { get; }
        ITransportTypeRepository TransportTypes { get; }
        IProductRepository       Products   { get; }
        IProductTypeRepository   ProductTypes { get; }

        void Save();
    }
}
