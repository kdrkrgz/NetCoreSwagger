using System.Collections.Generic;

namespace NetCoreSwagger.Infrastructure
{
    public interface IBookStoreBaseRepository<TEntity> where TEntity: class, IBaseEntity
    {
        TEntity Get(int id);
        List<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
    }
}