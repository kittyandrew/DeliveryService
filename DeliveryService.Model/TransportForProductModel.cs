using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class TransportForProductModel
    {
        public int Id;
        // We have to avoid mapping recusrsion, so..
        public TransportTypeModel TransportTypeModel { get; set; }
        public ProductTypeModel ProductTypeModel { get; set; }
    }
}
