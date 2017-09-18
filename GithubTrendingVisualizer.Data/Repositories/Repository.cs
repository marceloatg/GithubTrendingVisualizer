using GithubTrendingVisualizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GithubTrendingVisualizer.Data.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class, IEntity
    {
        private Context Context { get; }

        protected Repository(Context context)
        {
            Context = context;
        }

        public virtual (TEntity entity, Exception exception) GetById(int id)
        {
            TEntity entity = null;
            Exception exception = null;

            try { entity = Context.Set<TEntity>().Find(id); }
            catch (Exception e) { exception = e; }

            return (entity, exception);
        }

        public virtual (IEnumerable<TEntity> entities, Exception exception) List()
        {
            IEnumerable<TEntity> entities = null;
            Exception exception = null;

            try { entities = Context.Set<TEntity>().AsEnumerable(); }
            catch (Exception e) { exception = e; }

            return (entities, exception);
        }

        public virtual (IEnumerable<TEntity> entities, Exception exception) List(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = null;
            Exception exception = null;

            try
            {
                entities = Context.Set<TEntity>()
                    .Where(predicate)
                    .AsEnumerable();
            }
            catch (Exception e)
            {
                exception = e;
            }

            return (entities, exception);
        }

        public virtual (bool succeeded, Exception exception) Insert(TEntity entity)
        {
            var succeeded = false;
            Exception exception = null;

            try
            {
                if (entity.Id == Guid.Empty) { entity.Id = Guid.NewGuid(); }

                Context.Set<TEntity>().Add(entity);
                Context.SaveChanges();
                succeeded = true;
            }
            catch (Exception e)
            {
                exception = e;
            }

            return (succeeded, exception);
        }

        public virtual (bool succeeded, Exception exception) Update(TEntity entity)
        {
            var succeeded = false;
            Exception exception = null;

            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                succeeded = true;
            }
            catch (Exception e)
            {
                exception = e;
            }

            return (succeeded, exception);
        }

        public virtual (bool succeeded, Exception exception) Delete(TEntity entity)
        {
            var succeeded = false;
            Exception exception = null;

            try
            {
                Context.Set<TEntity>().Remove(entity);
                Context.SaveChanges();
                succeeded = true;
            }
            catch (Exception e)
            {
                exception = e;
            }

            return (succeeded, exception);
        }
    }
}