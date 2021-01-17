using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlainDotNetApi.Data.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : AbstractBaseModel
    {
        private readonly PGDatabaseContext _context;

        protected readonly DbSet<TModel> _modelDbSets;

        public BaseRepository(PGDatabaseContext context)
        {
            _context = context;
            _modelDbSets = _context.Set<TModel>();
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Add(TModel entity)
        {
            _modelDbSets.Add(entity);
        }

        public void AddRange(IEnumerable<TModel> entities)
        {
            _modelDbSets.AddRange(entities);
        }

        public async Task<TModel> GetAsync(Guid id)
        {
            return await GetAsync(x => x.Id == id);
        }

        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await _modelDbSets.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TModel>> GetListAsync()
        {
            return await _modelDbSets.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await _modelDbSets.AsNoTracking().Where(predicate).ToListAsync();
        }

        public IQueryable<TModel> Queryable(Expression<Func<TModel, bool>> predicate)
        {
            return _modelDbSets.Where(predicate);
        }

        public void Remove(TModel entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _modelDbSets.Attach(entity);

            _modelDbSets.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TModel> entities)
        {
            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State == EntityState.Detached) 
                    _modelDbSets.Attach(entity);

                _modelDbSets.Remove(entity);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges(); 
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(TModel entity)
        {
            _modelDbSets.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public bool Exists(Guid id)
        {
            return _modelDbSets.Any(e => e.Id == id);
        }
    }
}
