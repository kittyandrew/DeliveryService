using DeliveryService.Entity;
using DeliveryService.Model;

namespace DeliveryService.BLL.Impl.Mappers
{
    public static class TransportMapper
    {
        public static Transport ModelToEntity(this TransportModel transportModel)
        {
            return new Transport
            {
                Id = transportModel.Id,
                FreeBy = transportModel.FreeBy,
                TransportTypeId = transportModel.TransportTypeModel.Id,
                TransportType = TransportTypeMapper.ModelToEntity(transportModel.TransportTypeModel),
            };
        }

        public static TransportModel EntityToModel(this Transport transport)
        {
            return new TransportModel
            {
                Id = transport.Id,
                FreeBy = transport.FreeBy,
                TransportTypeModel = TransportTypeMapper.EntityToModel(transport.TransportType),
            };
        }
    }
}