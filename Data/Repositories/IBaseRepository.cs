using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlainDotNetApi.Data.Repositories
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity : AbstractBaseModel
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<int> SaveChangesAsync();
        void SaveChanges();
        bool Exists(Guid id);
    }
}
