using System.Linq.Expressions;
using AutoMapper;
using Data;

namespace Services
{
    public abstract class Service<TEntity, TViewModel>
        : IService<TEntity, TViewModel> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;

        private static readonly Mapper mapper = new Mapper(new MapperConfiguration(
            cfg => cfg.CreateMap<TEntity, TViewModel>().ReverseMap()
        ));

        public Service(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<TViewModel> GetAsync(int id)
        {
            try
            {
                TEntity result = await repository.GetAsync(id);
                TViewModel returnResult = mapper.Map<TViewModel>(result);
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<ICollection<TViewModel>> GetAllAsync()
        {
            try
            {
                ICollection<TEntity> result = await repository.GetAllAsync();
                ICollection<TViewModel> returnResult = mapper.Map<ICollection<TViewModel>>(result.ToList());
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TViewModel> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                TEntity result = await repository.FindAsync(predicate);
                TViewModel returnResult = mapper.Map<TViewModel>(result);
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<ICollection<TViewModel>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                ICollection<TEntity> result = await repository.FindAllAsync(predicate);
                ICollection<TViewModel> returnResult = mapper.Map<ICollection<TViewModel>>(result.ToList());
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TViewModel> AddAsync(TViewModel viewModel)
        {
            try
            {
                TEntity entity = mapper.Map<TEntity>(viewModel);
                TEntity result = await repository.AddAsync(entity);
                await repository.SaveChangesAsync();
                TViewModel returnResult = mapper.Map<TViewModel>(result);
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TViewModel> UpdateAsync(TViewModel viewModel, int key)
        {
            try
            {
                TEntity entity = mapper.Map<TEntity>(viewModel);
                TEntity result = await repository.UpdateAsync(entity, key);
                await repository.SaveChangesAsync();
                TViewModel returnResult = mapper.Map<TViewModel>(result);
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TViewModel> RemoveAsync(int key)
        {
            try
            {
                TEntity entity = await repository.RemoveAsync(key);
                if (entity == null)
                {
                    return default;
                }

                await repository.SaveChangesAsync();
                TViewModel returnResult = mapper.Map<TViewModel>(entity);
                return returnResult;
            }
            catch
            {
                throw;
            }
        }
    }
}

