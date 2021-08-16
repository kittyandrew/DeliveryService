using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class DeliveryModel
    {
        public int Id { get; set; }
        public DateTime DeliveryTime { get; set; }

        [ForeignKey("PlaceId")]
        public virtual PlaceModel PlaceModel { get; set; }
        public int PlaceId { get; set; }

        [ForeignKey("TransportId")]
        public virtual TransportModel TransportModel { get; set; }
        public int TransportId { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductModel ProductModel { get; set; }
        public int ProductId { get; set; }
    }
}
