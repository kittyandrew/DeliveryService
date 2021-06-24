using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Impl.Mappers
{
    public static class TransportTypeMapper
    {
        public static TransportType ModelToEntity(this TransportTypeModel transportTypeModel)
        {
            return new TransportType
            {
                Id = transportTypeModel.Id,
                Name = transportTypeModel.Name,
                MaxSize = transportTypeModel.MaxSize,
                MaxWeight = transportTypeModel.MaxWeight,
                Speed = transportTypeModel.Speed,
            };
        }

        public static TransportTypeModel EntityToModel(this TransportType transportType)
        {
            return new TransportTypeModel
            {
                Id = transportType.Id,
                Name = transportType.Name,
                MaxSize = transportType.MaxSize,
                MaxWeight = transportType.MaxWeight,
                Speed = transportType.Speed,
            };
        }
    }
}