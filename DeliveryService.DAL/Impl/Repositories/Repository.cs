using System.Collections.Generic;
using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.Entity;
using System.Linq;
using System;
using DeliveryService.DAL.Impl.EF;
using System.Data.Entity;

namespace DeliveryService.DAL.Impl.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        private readonly DeliveryServiceContext context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DeliveryServiceContext Context)
        {
            context = Context;
            DbSet = context.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual TEntity Get(TKey id)
        {
            return DbSet.Find(id);
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual void Update(TEntity entity)
        {
            TEntity old = Get(entity.Id);
            context.Entry(old).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }

}
