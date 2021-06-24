using System;

namespace DeliveryService.Entity
{
    public class Delivery : Base<int>
    {
        public DateTime DeliveryTime { get; set; }

        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }

        public int TransportId { get; set; }
        public virtual Transport Transport { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
