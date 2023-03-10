using WpfAppMvvmToolkit.API.Context.Entities;
using WpfAppMvvmToolkit.Core.Models;

namespace WpfAppMvvmToolkit.API.Services
{
    public interface IUserService
    {
        Task<ApiResponse> LoginAsync(string account, string password);
        Task<ApiResponse> Resgiter(UserDto user);
        Task<ApiResponse> UpdateAccount(UserDto user);
    }
}
