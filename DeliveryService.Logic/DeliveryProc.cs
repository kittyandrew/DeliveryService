using System;
using System.Configuration;
using System.Collections.Generic;
using DeliveryService.Dao;
using DeliveryService.Model;

namespace DeliveryService.Logic
{
    public class DeliveryProc : IDeliveryProc
    {
        private DaoObject dao;
        private readonly int MaxDistance;

        public DeliveryProc(DaoObject dao)
        {
            this.dao = dao;
            MaxDistance = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MaxDeliveryDistance"));
        }

        public int GetMaxDistance()
        {
            return MaxDistance;
        }

        public double GetApproximateTime(int distance)
        {
            double modificator = 0;
            DateTime now = DateTime.Now;

            // If this is some very popular time, there will be too many cars on the road.
            if ((now.Hour > 8 && now.Hour < 10) || (now.Hour > 15 && now.Hour < 17))
                modificator = 0.45;

            // Our
            return distance * 0.3 + distance * modificator;
        }

        // First id is delivery id, second is transport id.
        public (Guid, Guid) MakeDelivery(List<Product> products, int distance)
        {
            if (products == null || products.Count == 0)
                throw new ArgumentException($"Product list must be a valid non-empty list!");

            // Validate product size:
            if (distance <= 0 || distance > GetMaxDistance())
                throw new ArgumentException($"Delivery distance type must be a valid size, between '0' and '{GetMaxDistance()}': '{distance}'!");

            DeliveryPlace deliveryPlace = new DeliveryPlace(products, distance);
            Transport transport = AddDelivery(deliveryPlace);
            return (deliveryPlace.Id, transport.Id);
        }

        private Transport AddDelivery(DeliveryPlace deliveryPlace)
        {
            Transport transport = FillAnyTransport(deliveryPlace);
            if (transport == null)
            {
                // Otherwise, request new transport.
                foreach (TransportType transportType in Enum.GetValues(typeof(TransportType)))
                {
                    transport = new Transport(transportType);
                    if (IsCapableOfDelivery(transport, deliveryPlace))
                    {
                        transport.DeliveryPlaces.Add(deliveryPlace);
                        return transport;
                    }
                }
                // At this point, we now we just can't make this delivery due to size or weight.
                int totalSize = deliveryPlace.GetTotalDeliverySize();
                int totalWeight = deliveryPlace.GetTotalDeliveryWeight();
                throw new ArgumentException($"This delivery is impossible due to size ({totalSize}) or weight ({totalWeight}).");
            }
            return transport;
        }

        private Transport FillAnyTransport(DeliveryPlace deliveryPlace)
        {
            foreach (Transport transport in dao.TransportDao.GetAll())
            {
                if (IsCapableOfDelivery(transport, deliveryPlace)) {
                    transport.DeliveryPlaces.Add(deliveryPlace);
                    return transport;
                }
            }
            return null;
        }

        private bool IsCapableOfDelivery(Transport transport, DeliveryPlace deliveryPlace)
        {
            return transport.MaxSize   > transport.SizeTaken + deliveryPlace.GetTotalDeliverySize()
                && transport.MaxWeight > transport.WeightTaken + deliveryPlace.GetTotalDeliveryWeight();
        }

        public void FinishDelivery(Guid transportId, Guid deliveryPlaceId)
        {
            Transport transport = dao.TransportDao.Get(transportId);
            int index = transport.DeliveryPlaces.FindIndex((DeliveryPlace d) => d.Id.Equals(deliveryPlaceId));

            if (index != -1)
            {
                transport.DeliveryPlaces.RemoveAt(index);
            }
        }
    }
}
