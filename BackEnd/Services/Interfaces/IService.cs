using System.Linq.Expressions;

namespace Services
{
    public interface IService<TEntity, TViewModel> where TEntity : class
    {
        Task<TViewModel> AddAsync(TViewModel viewModel);
        Task<ICollection<TViewModel>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TViewModel> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TViewModel>> GetAllAsync();
        Task<TViewModel> GetAsync(int id);
        Task<TViewModel> RemoveAsync(int key);
        Task<TViewModel> UpdateAsync(TViewModel viewModel, int key);
    }
}

