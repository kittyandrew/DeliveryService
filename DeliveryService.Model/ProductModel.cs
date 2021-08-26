using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public ProductTypeModel ProductTypeModel { get; set; }
    }
}

