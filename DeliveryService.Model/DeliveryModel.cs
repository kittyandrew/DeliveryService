using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class DeliveryModel
    {
        public int Id { get; set; }
        public DateTime DeliveryTime { get; set; }

        [ForeignKey("PlaceId")]
        public PlaceModel PlaceModel { get; set; }

        [ForeignKey("TransportId")]
        public TransportModel TransportModel { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel ProductModel { get; set; }
    }
}
