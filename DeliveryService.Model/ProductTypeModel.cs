using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class ProductTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("TransportTypeId")]
        public TransportTypeModel TransportTypeModel { get; set; }
    }
}
