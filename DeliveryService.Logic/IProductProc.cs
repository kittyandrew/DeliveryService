using System;
using DeliveryService.Dao;
using DeliveryService.Model;

namespace DeliveryService.Logic
{
    public interface IProductProc
    {
        int GetMaxSize();
        int GetMaxWeight();

        Guid MakeProduct(ProductType productType, string name, int size, int weight);
        Product GetProduct(String guid);
    }
}
