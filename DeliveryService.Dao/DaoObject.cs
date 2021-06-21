using System;
using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Dao
{
    public class DaoObject
    {
        public IDao<DeliveryPlace> DeliveryPlaceDao { get; } = new Dao<DeliveryPlace>(new List<DeliveryPlace>());
        public IDao<Product> ProductDao { get; }             = new Dao<Product>      (new List<Product>());
        public IDao<Transport> TransportDao { get; }         = new Dao<Transport>    (new List<Transport>());
    }
}
