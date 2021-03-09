using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Viajeros.DA
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        protected DB _db { get; set; }
        protected DbSet<TEntity> _dbSet { get; set; }

        public Repository(DB db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }



        public virtual async Task<TEntity> GetAsync(int id, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (string include in includes)
                query = query.Include(include);


            return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _dbSet.Where(predicate);
            return await list.ToListAsync();
        }



        public virtual async Task<IList<TEntity>> GetListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IList<TEntity>> GetListAsync(params string[] includes)
        {
            var list = _dbSet.Where(x => x.Id > 0);
            foreach (string include in includes)
            {
                list = list.Include(include);

            }
            return await list.ToListAsync();
        }


        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }


        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
