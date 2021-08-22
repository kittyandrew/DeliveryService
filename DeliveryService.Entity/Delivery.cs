using System;

namespace DeliveryService.Entity
{
    public class Delivery : Base<int>
    {
        private static int nextId = 1;
        public DateTime DeliveryTime { get; set; }

        public int PlaceId { get; set; }

        public int TransportId { get; set; }

        public int ProductId { get; set; }

        public Delivery(DateTime deliveryTime, int placeId, int transportId, int productId)
        {
            Id = nextId++;
            DeliveryTime = deliveryTime;
            PlaceId = placeId;
            TransportId = transportId;
            ProductId = productId;
        }
    }
}
