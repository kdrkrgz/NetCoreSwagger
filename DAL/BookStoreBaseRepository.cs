using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetCoreSwagger.Infrastructure;

namespace NetCoreSwagger.DAL
{
    public class BookStoreBaseRepository<TEntity> : IBookStoreBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly BookStoreDbContext context;
        public BookStoreBaseRepository(BookStoreDbContext context)
        {
            this.context = context;
        }         
        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
            return entity;
        }


        public TEntity Get(int id)
        {
            return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }

}