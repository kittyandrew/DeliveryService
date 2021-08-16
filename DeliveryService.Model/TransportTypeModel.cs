using System;

namespace DeliveryService.Model
{
    public class TransportTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MaxSize { get; set; }
        public double MaxWeight { get; set; }
        public double Speed { get; set; }
    }
}
