using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Viajeros.DA
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(int id, params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetListAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> SaveChangesAsync();
        Task<IList<TEntity>> GetListAsync(params string[] includes);
    }
}

