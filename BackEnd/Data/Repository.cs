using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        protected ApiDataContext _context;

        protected Repository(ApiDataContext databaseContext)
        {
            _context = databaseContext;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity t)
        {
            await _context.Set<TEntity>().AddAsync(t);

            await SaveChangesAsync();
            return t;
        }

        public virtual async Task<IEnumerable<TEntity>> AddAllAsync(IEnumerable<TEntity> tList)
        {
            var itemstoAdd = tList as IList<TEntity> ?? tList.ToList();
            await _context.Set<TEntity>().AddRangeAsync(itemstoAdd);
            await SaveChangesAsync();
            return itemstoAdd;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity updated, int key)
        {
            if (updated == null)
            {
                return null;
            }

            TEntity? existing = await _context.Set<TEntity>().FindAsync(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
            }
            await SaveChangesAsync();
            return existing;
        }

        public virtual async Task<TEntity> RemoveAsync(int key)
        {
            TEntity? existing = await _context.Set<TEntity>().FindAsync(key);
            if (existing == null)
            {
                return null;
            }

            _context.Set<TEntity>().Remove(existing);
            await SaveChangesAsync();
            return existing;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }

}
