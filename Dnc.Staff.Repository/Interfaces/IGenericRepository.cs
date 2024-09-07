using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllIncludeAsync(Expression<Func<TEntity, object>>[] properties);
        Task<TEntity> FindByKey(int key);
        Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetByIncludeAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] properties);
        Task<int> AddAsync(TEntity entity);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
