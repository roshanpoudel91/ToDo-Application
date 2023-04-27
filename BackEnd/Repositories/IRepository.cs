using System.Linq.Expressions;

namespace Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> AddAllAsync(IEnumerable<TEntity> tList);
        Task<TEntity> AddAsync(TEntity t);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> RemoveAsync(int key);
        Task<int> SaveChangesAsync();
        Task<TEntity> UpdateAsync(TEntity updated, int key);
    }
}