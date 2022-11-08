using Microsoft.EntityFrameworkCore;
using Confitec.Infra;
using Confitec.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        public BaseRepository(DataContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.AnyAsync(where);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var entity = _dbSet.AsNoTrackingWithIdentityResolution().AsQueryable();

            if(includes != null) 
            {
                entity = includes.Aggregate(entity, (current, include) => current.Include(include));
            }

            return await entity.FirstOrDefaultAsync(where);
        }

        public IQueryable<T> ListAsQueryable(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes)
        {
            var entity = _dbSet.AsNoTrackingWithIdentityResolution().AsQueryable();

            if (includes != null)
            {
                entity = includes.Aggregate(entity, (current, include) => current.Include(include));
            }

            return entity.Where(where);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var entity = _dbSet.AsQueryable();

            if (includes != null)
            {
                entity = includes.Aggregate(entity, (current, include) => current.Include(include));
            }

            return await entity.FirstOrDefaultAsync(where);
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.FromResult(_dbSet.Remove(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.FromResult(_dbSet.Update(entity));
        }

        public IQueryable<T> ListAsQueryable()
        {
            var entity = _dbSet.AsNoTrackingWithIdentityResolution().AsQueryable();

            return entity;
        }
    }
}
