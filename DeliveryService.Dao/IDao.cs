using System;
using System.Collections.Generic;

namespace DeliveryService.Dao
{
    public interface IDao<T>
    {
        void Create(T Entity);
        void Put(T Entity);
        void Delete(Guid Id);
        T Get(Guid Id);
        List<T> GetAll();
    }
}
