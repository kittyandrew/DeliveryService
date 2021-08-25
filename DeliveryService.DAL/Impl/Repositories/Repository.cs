using System.Collections.Generic;
using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.Entity;
using System.Linq;
using System;

namespace DeliveryService.DAL.Impl.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        protected readonly ICollection<TEntity> DbSet;

        public Repository()
        {
            DbSet = new List<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual TEntity Get(TKey id)
        {
            return DbSet.Where(entity => entity.Id.Equals(id)).First();
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return DbSet;
        }

        // Hack to work with ICollection.
        public virtual void Update(TEntity entity)
        {
            Delete(entity.Id);
            Create(entity);
        }

        public virtual void Delete(TKey id)
        {
            DbSet.Remove(Get(id));
        }
    }

}
