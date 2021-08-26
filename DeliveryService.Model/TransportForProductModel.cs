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
        public TransportTypeModel TransportType { get; set; }
        public ProductTypeModel ProductTypeModel { get; set; }
    }
}
