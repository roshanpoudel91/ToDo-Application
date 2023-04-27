using Services.DataTransferObjects;

namespace Services
{
    public interface IRoleService
    {
        Task<ICollection<RoleView>> GetAllAsync();
        Task<RoleView> GetAsync(string id);
        Task<RoleView> AddAsync(RoleView roleView);
        Task<RoleView> UpdateAsync(RoleView role, string id);
        Task<RoleView> RemoveAsync(string id);
    }
}

