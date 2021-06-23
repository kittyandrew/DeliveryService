using System;
using System.Configuration;
using System.Collections.Generic;

namespace DeliveryService.Model
{
    public class Transport : Base
    {
        public TransportType TransportType { get; private set; }
        public List<DeliveryPlace> DeliveryPlaces { get; }

        public int MaxSize { get; }
        public int SizeTaken { get; }
        public int MaxWeight { get; }
        public int WeightTaken { get; }
        public int Speed { get; private set; }

        public Transport(TransportType transportType)
        {
            TransportType = transportType;
            DeliveryPlaces = new List<DeliveryPlace>();

            SizeTaken = 0;
            WeightTaken = 0;
            switch (transportType)
            {
                case TransportType.SUV:
                    MaxSize =   Convert.ToInt32(ConfigurationManager.AppSettings.Get("SUVMaxSize"));
                    MaxWeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SUVMaxWeight"));
                    Speed =     Convert.ToInt32(ConfigurationManager.AppSettings.Get("SUVSpeed"));
                    break;
                case TransportType.VAN:
                    MaxSize =   Convert.ToInt32(ConfigurationManager.AppSettings.Get("VANMaxSize"));
                    MaxWeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("VANMaxWeight"));
                    Speed =     Convert.ToInt32(ConfigurationManager.AppSettings.Get("VANSpeed"));
                    break;
                case TransportType.TRUCK:
                    MaxSize =   Convert.ToInt32(ConfigurationManager.AppSettings.Get("TRUCKMaxSize"));
                    MaxWeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("TRUCKMaxWeight"));
                    Speed =     Convert.ToInt32(ConfigurationManager.AppSettings.Get("TRUCKSpeed"));
                    break;
            }
        }

        public override string ToString()
        {
            return $"Transport(Id={Id}, Places='{DeliveryPlaces.Count} places', "
                 + $"Size={SizeTaken}/{MaxSize}, Weight={WeightTaken}/{MaxWeight}, Speed={Speed})";
        }
    }
}
