using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class DeliveryModel
    {
        public int Id { get; set; }
        public DateTime DeliveryTime { get; set; }
        public PlaceModel PlaceModel { get; set; }
        public TransportModel TransportModel { get; set; }
        public ProductModel ProductModel { get; set; }
    }
}
