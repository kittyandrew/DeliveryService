using System.Collections.Generic;
using DeliveryService.Entity;

namespace DeliveryService.DAL.Abstr.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        ICollection<TEntity> GetAll();
        TEntity Get(TKey id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TKey id);
    }
}
