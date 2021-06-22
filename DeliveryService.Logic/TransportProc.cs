using System;
using DeliveryService.Dao;
using DeliveryService.Model;

namespace DeliveryService.Logic
{
    public class TransportProc
    {
        private DaoObject dao;

        public TransportProc(DaoObject dao)
        {
            this.dao = dao;
        }

        public void AddDelivery(DeliveryPlace deliveryPlace)
        {
            if (!FillAnyTransport(deliveryPlace))
            {
                // Otherwise, request new transport:
                Transport newVehicle = new Transport(TransportType.VAN, 15);
                newVehicle.DeliveryPlaces.Add(deliveryPlace);
                dao.TransportDao.Create(newVehicle);
            }
        }

        public bool FillAnyTransport(DeliveryPlace deliveryPlace)
        {
            foreach (Transport transport in dao.TransportDao.GetAll())
            {
                if (IsCapableOfDelivery(transport, deliveryPlace)) {
                    transport.DeliveryPlaces.Add(deliveryPlace);
                    return true;
                }
            }
            return false;
        }

        public bool IsCapableOfDelivery(Transport transport, DeliveryPlace deliveryPlace)
        {
            return transport.MaxSize   > transport.SizeTaken + deliveryPlace.GetTotalDeliverySize()
                && transport.MaxWeight > transport.MaxWeight + deliveryPlace.GetTotalDeliveryWeight();
        }
    }
}
