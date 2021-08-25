using System;

namespace DeliveryService.Entity
{
    public class Delivery : Base<int>
    {
        private static int nextId = 1;
        public DateTime DeliveryTime { get; set; }

        public Place Place { get; set; }

        public Transport Transport { get; set; }

        public Product Product { get; set; }

        public Delivery(DateTime deliveryTime, Place place, Transport transport, Product product)
        {
            Id = nextId++;
            DeliveryTime = deliveryTime;
            Place = place;
            Transport = transport;
            Product = product;
        }
    }
}
