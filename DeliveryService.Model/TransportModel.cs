using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class TransportModel
    {
        public int Id { get; set; }
        public DateTime FreeBy { get; set; }

        [ForeignKey("TransportTypeId")]
        public TransportTypeModel TransportTypeModel { get; set; }
        public int TransportTypeId { get; set; }
    }
}
