using System;
using System.Collections.Generic;
using DeliveryService.Model;

namespace DeliveryService.Dao
{
    public class Dao<T> : IDao<T> where T : Base
    {
        private List<T> _entities;

        public Dao(List<T> storage)
        {
            _entities = storage;
        }

        public void Create(T Entity)
        {
            _entities.Add(Entity);
        }

        public void Put(T Entity)
        {
            int TmpIndex = _entities.FindIndex((T entity) => entity.Id.Equals(Entity.Id));
            _entities[TmpIndex] = Entity;
        }

        public void Delete(Guid Id)
        {
            _entities.RemoveAll((T entity) => entity.Id.Equals(Id));
        }

        public T Get(Guid Id)
        {
            return _entities.Find((T entity) => entity.Id.Equals(Id));
        }

        public List<T> GetAll()
        {
            return _entities;
        }
    }
}
