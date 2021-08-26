using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class ProductTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TransportForProductModel> TransportForProductModels { get; set; }

        public ProductTypeModel()
        {
            TransportForProductModels = new List<TransportForProductModel>();
        }
    }
}
