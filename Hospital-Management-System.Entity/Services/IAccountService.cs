using Hospital_Management_System.Entity.ViewModels;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entity.Services
{
    public interface IAccountService
    {
        Task<(string, int?, string)> FindByNameAsync(LoginViewModel model);
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task SignOutAsync();
    }
}
