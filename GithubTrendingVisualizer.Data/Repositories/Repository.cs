using GithubTrendingVisualizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GithubTrendingVisualizer.Data.Repositories
{
    public abstract class Repository<TEntity> where TEntity: class, IEntity
    {
        private Context Context { get; }

        protected Repository(Context context)
        {
            Context = context;
        }

        public virtual TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> List()
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>()
                .Where(predicate)
                .AsEnumerable();
        }

        public virtual void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }
    }
}