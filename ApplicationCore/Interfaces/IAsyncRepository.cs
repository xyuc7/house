using System.Linq.Expressions;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        public interface IAsyncRepository<TEntity> where TEntity : class
        {
            Task<TEntity> AddAsync(TEntity entity);
            Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
            Task<TEntity> UpdateAsync(TEntity entity);
            Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities);
            Task DeleteAsync(TEntity entity);
            Task DeleteRangeAsync(IEnumerable<TEntity> entities);
            Task<TEntity> GetByIdAsync<TId>(TId id) where TId : struct;
            Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
            Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
            Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
            Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);
            Task<List<TEntity>> ListAsync();
        }

    }
}