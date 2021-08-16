using System.Collections.Generic;
using DeliveryService.DAL.Abstr.Repositories;
using DeliveryService.DAL.Impl.EF;
using DeliveryService.Entity;
using System.Data.Entity;
using System.Linq;

namespace DeliveryService.DAL.Impl.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        private readonly DeliveryServiceContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DeliveryServiceContext context)
        {
            Context = context;
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

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual void Update(TEntity entity)
        {
            TEntity find = Get(entity.Id);
            Context.Entry(find).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            TEntity find = Get(entity.Id);
            DbSet.Remove(find);
        }
    }

}
