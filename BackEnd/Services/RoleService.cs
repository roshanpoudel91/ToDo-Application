using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Services.DataTransferObjects;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager, IMapper mapper)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<RoleView> AddAsync(RoleView roleView)
        {
            try
            {
                var newRole = new Role()
                {
                    Name = roleView.Name,
                    NormalizedName = roleView.Name.ToUpper(),
                    Description = roleView.Description
                };

                var result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    var returnResult = _mapper.Map<RoleView>(newRole);
                    return returnResult;
                }

                var errors = result.Errors.Select(x => x.Description).ToArray();
                throw new ApplicationException(string.Join(",", errors));
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<RoleView>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = _roleManager.Roles.ToList();
                    ICollection<RoleView> returnResult = _mapper.Map<ICollection<RoleView>>(result.ToList());
                    return returnResult;
                }
                catch
                {
                    throw;
                }
            });
        }

        public async Task<RoleView> GetAsync(string id)
        {
            try
            {
                var result = await _roleManager.FindByIdAsync(id);
                RoleView returnResult = _mapper.Map<RoleView>(result);
                return returnResult;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleView> RemoveAsync(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return default;
                }

                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return default;
                }

                var errors = result.Errors.Select(x => x.Description).ToArray();
                throw new ApplicationException(string.Join(",", errors));
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleView> UpdateAsync(RoleView roleView, string id)
        {
            try
            {
                if (roleView == null || string.IsNullOrEmpty(id) || roleView.Id != id)
                {
                    return null;
                }

                var existing = await _roleManager.FindByIdAsync(id);
                if (existing != null)
                {
                    existing.Name = roleView.Name;
                    existing.NormalizedName = roleView.Name;

                    var result = await _roleManager.UpdateAsync(existing);

                    if (result.Succeeded)
                    {
                        existing = await _roleManager.FindByIdAsync(id);
                        var returnResult = _mapper.Map<RoleView>(existing);
                        return returnResult;
                    }

                    var errors = result.Errors.Select(x => x.Description).ToArray();
                    throw new ApplicationException(string.Join(",", errors));
                }
                return default;
            }
            catch
            {
                throw;
            }
        }
    }
}
