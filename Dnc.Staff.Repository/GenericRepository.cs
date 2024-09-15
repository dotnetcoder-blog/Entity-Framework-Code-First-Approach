using Dnc.Staff.Data;
using Dnc.Staff.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Staff.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public StaffDbContext Context { get; }
        public DbSet<TEntity> Table { get; }

        public GenericRepository(StaffDbContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Table.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllIncludeAsync(Expression<Func<TEntity, object>>[] properties)
        {
            var queryable = Table.AsNoTracking();
            foreach (var property in properties)
            {
                queryable = queryable.Include(property);
            }
            return await queryable.ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetByIncludeAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] properties)
        {
            var queryable = Table.AsNoTracking();
            var query = properties.Aggregate(queryable, (current, property) => current.Include(property));
            return await query.Where(predicate).ToListAsync();
        }
        public async Task<TEntity> FindByKey(int key)
        {
            return await Table.AsNoTracking().SingleOrDefaultAsync(BuildLambda<TEntity>(key));
        }
        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return await SaveChangesAsync();
        }
        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            return await SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            return await SaveChangesAsync();
        }
        public async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return await SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            return await SaveChangesAsync();
        }
        public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
            return await SaveChangesAsync();
        }
        private static Expression<Func<TItem, bool>> BuildLambda<TItem>(int id)
        {
            var item = Expression.Parameter(typeof(TItem), "item");
            var property = Expression.Property(item, "Id");
            var constant = Expression.Constant(id);
            var equal = Expression.Equal(property, constant);
            return Expression.Lambda<Func<TItem, bool>>(equal, item);
        }
        private async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }
    }
}
