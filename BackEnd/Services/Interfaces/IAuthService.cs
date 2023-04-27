using Services.DataTransferObjects;

namespace Services
{
    public interface IAuthService
    {
        Task<UserView> LoginAsync(UserView userView);
        Task LogoutAsync();
    }
}

