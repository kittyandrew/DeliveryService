using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Entity
{
    public class Delivery : Base<int>
    {
        [Column(TypeName = "datetime2")]
        public DateTime DeliveryTime { get; set; }

        // [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
        public int PlaceId { get; set; }

        // [ForeignKey("TransportId")]
        public virtual Transport Transport { get; set; }
        public int TransportId { get; set; }

        // [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
