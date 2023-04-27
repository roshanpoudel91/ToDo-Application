using Services.DataTransferObjects;

namespace Services
{
    public interface IUserService
    {
        Task<ICollection<UserView>> GetAllAsync();
        Task<ICollection<UserView>> GetAllByRole(string role);
        Task<UserView> GetAsync(string id);
        Task<UserView> AddAsync(UserView userView);
        Task<UserView> UpdateAsync(UserView user, string id);
        Task<UserView> RemoveAsync(string id);
    }
}

