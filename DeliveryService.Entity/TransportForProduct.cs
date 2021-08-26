using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Entity
{
    public class TransportForProduct : Base<int>
    {
        [ForeignKey("TransportTypeId")]
        public virtual TransportType TransportType { get; set; }
        public int TransportTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public TransportForProduct()
        {

        }
        public TransportForProduct(int transportTypeId, int productTypeid)
        {
            TransportTypeId = transportTypeId;
            ProductTypeId = productTypeid;
        }
    }
}
