using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Entity
{
    public class Transport: Base<int>
    {
        [Column(TypeName = "datetime2")]
        public DateTime FreeBy { get; set; }

        // [ForeignKey("TransportTypeId")]
        public virtual TransportType TransportType { get; set; }
        public int TransportTypeId { get; set; }

        public Transport()
        {

        }
        public Transport(DateTime freeBy, int transportTypeId)
        {
            FreeBy = freeBy;
            TransportTypeId = transportTypeId;
        }
    }
}
