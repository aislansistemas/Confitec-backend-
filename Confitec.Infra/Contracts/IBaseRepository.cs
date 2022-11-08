using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Infra.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task<T> FindAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        IQueryable<T> ListAsQueryable(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        IQueryable<T> ListAsQueryable();
        Task<bool> AnyAsync(Expression<Func<T, bool>> where);
    }
}
