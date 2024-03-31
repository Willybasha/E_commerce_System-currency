using E_commerce_System_currency.Services.DTOs;

namespace E_commerce_System_currency.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModelDto model);

        Task<AuthModel> GetTokenAsync(LoginRequestDto model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
