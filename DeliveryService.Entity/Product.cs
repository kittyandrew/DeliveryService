using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Entity
{
    public class Product : Base<int>
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }

        // [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public Product()
        {

        }
        public Product(string name, double size, double weight, int productTypeId)
        {
            Name = name;
            Size = size;
            Weight = weight;
            ProductTypeId = productTypeId;
        }
    }
}

