using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Management_System.Entity.ViewModels;

namespace Hospital_Management_System.Entity.Services
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<(string, int?)> FindByNameAsync(LoginViewModel model); // Tuple döndürmek için güncellendi
        Task<UserViewModel> Find(string username);
        Task<string> CreateRoleAsync(RoleViewModel model);
        Task<List<RoleViewModel>> GetAllRoles();
        Task SignOutAsync();
    }
}
