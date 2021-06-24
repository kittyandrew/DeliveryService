using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductTypeModel ProductTypeModel { get; set; }
    }
}

